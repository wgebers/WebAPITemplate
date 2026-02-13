

namespace WebAPITests;

public class GenericUnitTests
{

    // baseline test to ensure xunit is building correctly 
    [Fact]
    public void BaseLineTests()
    {
        int variable_to_test = 1;
        Assert.Equal(1,variable_to_test);
        string string_to_test = "helloworld";
        Assert.Equal("helloworld",string_to_test,ignoreCase: false);
        
    }
    
}
