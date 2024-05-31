using Microsoft.AspNetCore.Authentication;
using System.Linq;
using System.Security.Claims;

namespace WebAPI.Configuration.Middleware.Authentication;

public class CustomMyAuthenticationSchemeOptions : AuthenticationSchemeOptions
{
    public const string SchemeName = "HUBAutenticacao";
    public IEnumerable<PolicyWithClaim> PoliciesWithClaims { get; set; }

    public static IEnumerable<PolicyWithClaim> GetPolicies()
    {
        string arrAction = "read,post,put";
        string actionPost = "post";
        string actionPut = "put";
        string actionRead = "read";

        // No PolicyName definimos um nome da politica para ser utilizada no Annotation [Authorize(Policy = "")] das controllers
        // No ClaimType passamos o nome da claim e no ClaimValue o valor o valor que vai ser validado
        IEnumerable<PolicyWithClaim> PoliciesWithClaims = new List<PolicyWithClaim>
        {
        new PolicyWithClaim { PolicyName = "GetProfileByFiltersPolicy", ClaimType = "EClaim.ProfileConsulta.GetDescription()", ClaimValue = arrAction },
        new PolicyWithClaim { PolicyName = "InsuredJudicial", ClaimType = string.Empty, ClaimValue = string.Empty, HasMultiplePolicies = true,
                              PoliciesWithClaims = new List<MultiplePolicyWithClaim> {
                                new MultiplePolicyWithClaim { ClaimType = "EClaim.ProfileRead.GetDescription()", ClaimValue = actionRead },
                                new MultiplePolicyWithClaim { ClaimType = "EClaim.ProfilePost.GetDescription()", ClaimValue = actionPost },
                                new MultiplePolicyWithClaim { ClaimType = "EClaim.ProfilePut.GetDescription()", ClaimValue = actionPut },
                              }
                            },
        };

        return PoliciesWithClaims;
    }
}

public record PolicyWithClaim : GenericPolicyWithClaim
{
    public string PolicyName { get; set; }
    public bool HasMultiplePolicies { get; set; }
    public virtual IEnumerable<MultiplePolicyWithClaim> PoliciesWithClaims { get; set; }

    public PolicyWithClaim()
    {
        HasMultiplePolicies = false;
    }
}

public record MultiplePolicyWithClaim : GenericPolicyWithClaim
{

}

public abstract record GenericPolicyWithClaim
{
    public string ClaimType { get; set; }
    public string ClaimValue { get; set; }
}
