using System.Globalization;
using System.Reflection;
using Xunit.Sdk;

namespace OOMLSharp.Test.Utility;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
public class UseCultureAttribute : BeforeAfterTestAttribute
{
    private readonly CultureInfo _culture;
    private CultureInfo _originalCulture;
    private CultureInfo _originalUICulture;

    public string CultureName { get; set; } = "en-us";

    public UseCultureAttribute(string cultureName)
    {
        _originalCulture = CultureInfo.InvariantCulture;
        _originalUICulture = CultureInfo.InvariantCulture;
        _culture = CultureInfo.CreateSpecificCulture(CultureName);
    }

    public override void Before(MethodInfo methodUnderTest)
    {
        (_originalCulture, _originalUICulture) = (CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture);
        (CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture) = (_culture, _culture);
    }

    public override void After(MethodInfo methodUnderTest)
    {
        (CultureInfo.CurrentCulture, CultureInfo.CurrentUICulture) = (_originalCulture, _originalUICulture);
    }
}