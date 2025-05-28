/************************************************************
 * Autor: Gaina Alexandru
 * Data crearii: 2025-05-20
 * Ultima modificare: 2025-05-25
 * Fisier: UnitTest1.cs
 * Functionalitate: Teste pentru functionalitatea aplicatiei
 ************************************************************/
using MatchManager;
using PasswordHasher;
using UserLib;
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


    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void User_constructor_1()
    {
        User user = new User(".","parola",0);
    }

    [TestMethod]
    public void User_constructor_2()
    {
        User user = new User("1234", "parola", 0);
    }
    // nu poti avea '.' in username
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void User_constructor_3()
    {
        User user = new User("Gaina.10", "parola", 0);
    }
    //trebuie sa aiba minim 3 caractere username-ul
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void User_constructor_4()
    {
        User user = new User("gx", "parola", 0);
    }

    //trebuie sa aiba maxim 16 caractere username-ul
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void User_constructor_5()
    {
        User user = new User("qwertyuiopasdfghj", "parola", 0);
    }

    //sunt permise doar litere , numere si '_'
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void User_constructor_6()
    {
        User user = new User("beto.4", "parola", 0);
    }

}