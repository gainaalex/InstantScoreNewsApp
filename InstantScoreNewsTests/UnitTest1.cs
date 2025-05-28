using MatchManager;
using PasswordHasher;
namespace InstantScoreNewsTests;

[TestClass]
public class UnitTest1
{
    ProxyMatchManager proxy=new ProxyMatchManager();
    [TestMethod]
    public void Test_Login_1()
    {
        Assert.AreEqual(true, proxy.Login("admin", "admin"));
    }

    [TestMethod]
    public void Test_Login_2()
    {
        Assert.AreEqual(false, proxy.Login("admin", "1234"));
    }

    [TestMethod]
    public void Test_Login_3()
    {
        Assert.AreEqual(true, proxy.Login("alex", "alex"));
    }

    [TestMethod]
    public void Test_Login_4()
    {
        Assert.AreEqual(false, proxy.Login("ana", "Ana"));
    }

    [TestMethod]
    public void Test_Login_5()
    {
        Assert.AreEqual(false, proxy.Login("ruben", "Ruben"));
    }



}