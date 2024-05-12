
Refresh Token
//Server
 //Refresh Token
 public async Task<LoginResponse> RefreshToken()
 {
     var httpContext = contextAccessor.HttpContext;
     if (httpContext == null)
     {
         return new LoginResponse(null!, "Error Occured", HttpStatusCode.BadRequest);
     }
     var tokenValue = httpContext.Request.Cookies["Token"];
     if (tokenValue == null)
     {
         return new LoginResponse(null!, "User Not Authenticated", HttpStatusCode.BadRequest);
     }
     var handler = new JwtSecurityTokenHandler();
     var cookieToken = handler.ReadJwtToken(tokenValue);

     // Retrieve the user's Id claim from the token
     var userId = cookieToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

     var getUser = await context.Users.FirstOrDefaultAsync(user=> user.Id == int.Parse(userId));
     if (getUser is null)
         return new LoginResponse(null!, "User not found", HttpStatusCode.NotFound);

     string token = CreateTokenAsync(getUser);

     return new LoginResponse(token, "Login Successfully", HttpStatusCode.OK);
 }

 //RefreshToken
 Task<LoginResponse> RefreshToken();

//Controller
[HttpGet("refresh-token")]
public async Task<ActionResult> RefreshTokenController()
{
    var response = await _authService.RefreshToken();

    switch (response.ResponseCode)
    {
        case HttpStatusCode.OK:
            CookieOptions cookieOptions = new CookieOptions
            {
                HttpOnly = true,
            };
            Response.Cookies.Append("Token", response.Token, cookieOptions);
            return Ok(response.Token);
        case HttpStatusCode.BadRequest:
            return BadRequest(response.Message);
        case HttpStatusCode.NotFound:
            return NotFound(response.Message);
        default:
            return BadRequest("Error Occured, Try Again Later");
    }
}



//Client
//RefreshToken
public async Task<string?> RefreshToken()
{
    var response = await httpClient.GetStringAsync("api/auth/refresh-token");

    if (response != null)
    {
        var tokenResponse = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
        {
            Content = new StringContent(response)
        };

        var data = await SetToken(tokenResponse);
        return data;
    }
    else
    {
        navigationManager.NavigateTo("/login");
        return null;
    }
}

//Interface
Task<string?> RefreshToken();

//App.razor
 if (string.IsNullOrEmpty(ClientAuthService.Token.Value))
 {
     var refreshToken = await ClientAuthService.RefreshToken();
     if (!string.IsNullOrEmpty(refreshToken))
     {
         AuthenticationState auth_state = await AuthStateProvider.GetAuthenticationStateAsync();
         ClientAuthService.User.Id = int.Parse(auth_state.User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value!);
     }
 }
