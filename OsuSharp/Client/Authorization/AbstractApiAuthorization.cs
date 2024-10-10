using OsuSharp.Client.Core;

namespace OsuSharp.Client.Authorization;

public abstract class AbstractApiAuthorization(Dictionary<string, string> value)
{
  public readonly Dictionary<string, string> _authorizationBody = value;
  public string AccessToken {get; protected set; } = "";
	public DateTimeOffset ExpirationDate {get; protected set; } = DateTimeOffset.MinValue;
	public bool Status {get; protected set; } = false;

  protected static FormUrlEncodedContent EncodeFormUrl(Dictionary<string, string> parameters) {
    return new FormUrlEncodedContent(parameters);
	}
	
	internal abstract Task AuthorizationFlowAsync(OsuApiClientInternal svc);

	internal abstract Task RefreshAccessToken(OsuApiClientInternal svc);
	
	public override string ToString() {
		return "ApiAuthorization [accessToken=" + AccessToken + ", expirationDate=" + ExpirationDate + "]";
	}
}