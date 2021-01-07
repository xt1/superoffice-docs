---
# This basic template provides core metadata fields for Markdown articles on docs.superoffice.com.

# Mandatory fields.
title: oidc_implicit_flow       # (Required) Very important for SEO. Intent in a unique string of 43-59 chars including spaces.
description: OICD implicit flow # (Required) Important for SEO. Recommended character length is 115-145 characters including spaces.
author: {github-id}             # Your GitHub alias.
keywords:
so.topic: concept          # article, howto, reference, concept, guide

# Optional fields. Don't forget to remove # if you need a field.
so.envir: cloud           # cloud or onsite
so.client: online               # online, web, win, pocket, or mobile
---

# OICD implicit flow

In the implicit flow, the client application requests an ID token and possibly also an access token.  

## Scenario: client application requests ID token only

1. The user clicks **Sign in**.

2. The client application redirects the user agent to the [authorization endpoint][1] of the identity provider.
    * **Response type** is set to `id_token`, indicating the implicit flow and that we’re requesting an [ID token][2] only.
    * A nonce value is set to mitigate replay attacks.

```http
GET Request (test in a browser to handle login/redirect)https://sod.superoffice.com/login/common/oauth/authorize?
response_type=id_token&
client_id=db1834037c58c02b6bd9898feef19845&
redirect_uri=http://localhost/openid/index.html&
scope=openid&
state=12345&
nonce=7362CAEA-9CA5-4B43-9BA3-34D7C303EBA7
```

  Parameters are described below.

3. The user enters their credentials.

4. An identity provider authenticates the user and asks for consent to access their resources on behalf of the relying party.

5. With consent given, the authentication server sends an authorization response message from its authorization endpoint. This redirects the user-agent back to the relying party using the redirection URI provided earlier. This URI includes an ID token in a URI fragment (host address and `id_token` separated by hash (#)). This ID token contains the standard claims, including some claims normally found in the profile and email scopes.

[!include[implicit-flow-id-only-response](./includes/implicit-flow-id-only-response.md)]

6. The user agent needs to parse the ID token encoded values that were returned in the URI fragment, and then pass them to the client’s processing logic.
    * The application will likely contain a script that extracts the ID token from the full redirect URI.

7. It’s then up to the client application to validate the ID token before accessing and trusting the claims it contains.

### Parameters

| Parameter | Required | Description |
|-----------|:--------:|-------------|
| response\_type | yes | Value is `id_token token` or `id_token`.
| client\_id | yes | The client ID (application ID) assigned to your app when you registered with SuperOffice. |
| redirect\_uri | yes| The [redirection endpoint][4] of your app, where authentication responses are sent and received.<br>It must exactly match one of the URLs registered with SuperOffice.
| nonce | yes | String value used to associate a client session with an ID token, and to mitigate replay attacks.<br>Client must verify value. |
| [scope][3] | yes | Must be `openid`. |
| state | recommended | A value set by the relying party to maintain state between the request and the callback itself.<br>Included in the request and also returned in the token response. |

## Scenario: client application requests both ID token and access token

This scenario is almost the same as the [ID token][2] only scenario, except here we set **response type** to `token id_token`.

```http
GET Request (test in a browser to handle the login/redirect)https://sod.superoffice.com/login/common/oauth/authorize?
response_type=token id_token&
client_id=db1834037c58c02b6bd9898feef19845&
redirect_uri=http://localhost/openid/index.html&
scope=openid&
state=12345&
nonce=7362CAEA-9CA5-4B43-9BA3-34D7C303EBA7
```

After user authentication and consent is given, instead of just an ID token, the identity provider **also sends an [access token][5] in a URI fragment**.

[!include[implicit-flow-access-token-response](./includes/implicit-flow-access-token-response.md)]

### Parameters

| Parameter | Description |
|-----------|-------------|
| access\_token | The access token issued by the authorization server. |
| token\_type | Provides the client with the information required to successfully utilize the access token to make a protected resource request. |
| state | String value used to associate a client session with an ID token, and to mitigate replay attacks. |
| expires\_in | The lifetime in seconds of the access token. |
| id\_token | JWT, which consists of a Header, Payload, and Signature. The claims in the token form part of the payload. |

The client application can validate the ID token, and use the access token and token type to access the tenant's web services.

<!-- Referenced links -->
[1]: https://community.superoffice.com/en/developer/create-apps/concepts/authentication/endpoints/
[2]: ../id-token.md
[3]: claims-scope.md
[4]: ../../redirects/index.md
[5]: ../access-token.md