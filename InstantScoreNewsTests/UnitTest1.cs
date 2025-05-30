/************************************************************
 * Autor: Gaina Alexandru
 * Data crearii: 2025-05-20
 * Ultima modificare: 2025-05-25
 * Fisier: UnitTest1.cs
 * Functionalitate: Teste pentru functionalitatea aplicatiei
 ************************************************************/
using MatchManager;
using PasswordHasher;
using MatchManager;
using MatchStats;
using System.Text.RegularExpressions;
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

    // acelas input trebuie sa returneze acelas hash
    [TestMethod]
    public void PasswordHasher_HashString_1()
    {
        string input = "parola123";
        string hash1 = PasswordHasher.PasswordHasher.HashString(input);
        string hash2 = PasswordHasher.PasswordHasher.HashString(input);
        Assert.AreEqual(hash1, hash2);
    }

    // inputuri diferite trebuie sa returneze hashuri diferite
    [TestMethod]
    public void PasswordHasher_HashString_2()
    {
        string hash1 = PasswordHasher.PasswordHasher.HashString("parola123");
        string hash2 = PasswordHasher.PasswordHasher.HashString("Parola123");
        Assert.AreNotEqual(hash1, hash2);
    }

    // inputul gol trebuie sa returneze un hash valid (nevid)
    [TestMethod]
    public void PasswordHasher_HashString_3()
    {
        string hash = PasswordHasher.PasswordHasher.HashString("");
        Assert.IsFalse(string.IsNullOrEmpty(hash));
    }

    // inputul cu caractere unicode trebuie procesat corect
    [TestMethod]
    public void PasswordHasher_HashString_4()
    {
        string input = "ășțâîă";
        string hash = PasswordHasher.PasswordHasher.HashString(input);
        Assert.IsFalse(string.IsNullOrEmpty(hash));
    }

    // hashul generat trebuie sa aiba 28 de caractere (base64)
    [TestMethod]
    public void PasswordHasher_HashString_5()
    {
        string input = "test";
        string hash = PasswordHasher.PasswordHasher.HashString(input);
        Assert.AreEqual(28, hash.Length);
    }

    // adaugarea unui meci trebuie sa il includa in lista
    [TestMethod]
    public void AddMatch()
    {
        var manager = new RealMatchManager();
        var match = new MatchStats.Match("Steaua", "Dinamo", 2, 1);
        manager.AddMatch(match);
        var matches = manager.GetMatches();
        Assert.IsTrue(matches.Contains(match));
    }

    // stergerea unui meci trebuie sa il elimine din lista
    [TestMethod]
    public void RealMatchManager_RemoveMatch()
    {
        var manager = new RealMatchManager();
        var match = new MatchStats.Match("Rapid", "CFR", 1, 1);
        manager.AddMatch(match);
        manager.RemoveMatch(match);
        var matches = manager.GetMatches();
        Assert.IsFalse(matches.Contains(match));
    }

    // actualizarea unui meci modifica scorurile
    [TestMethod]
    public void RealMatchManager_UpdateMatch()
    {
        var manager = new RealMatchManager();
        var oldMatch = new MatchStats.Match("Uni", "Poli", 0, 0);
        var updated = new MatchStats.Match("Uni", "Poli", 3, 2);
        manager.AddMatch(oldMatch);
        manager.UpdateMatch(oldMatch, updated);
        var result = manager.GetMatches().FirstOrDefault(m => m.Equals(oldMatch));
        Assert.IsNotNull(result);
        Assert.AreEqual(3, result.ScorGazda);
        Assert.AreEqual(2, result.ScorOaspete);
    }

    // adaugarea unui eveniment trebuie sa il includa in lista meciului
    [TestMethod]
    public void RealMatchManager_AddEvent()
    {
        var manager = new RealMatchManager();
        var match = new MatchStats.Match("Farul", "FCSB", 1, 0);
        var ev = new Event(22, "Farul a dat gol");
        manager.AddMatch(match);
        manager.AddEvent(match, ev);
        var events = manager.GetEvents(match);
        Assert.IsTrue(events.Contains(ev));
    }

    // stergerea unui eveniment trebuie sa il elimine din lista
    [TestMethod]
    public void RealMatchManager_DeleteEvent()
    {
        var manager = new RealMatchManager();
        var match = new MatchStats.Match("UTA", "Voluntari", 1, 1);
        var ev = new Event(10, "Cartonas galben");
        manager.AddMatch(match);
        manager.AddEvent(match, ev);
        manager.DeleteEvent(match, ev);
        var events = manager.GetEvents(match);
        Assert.IsFalse(events.Contains(ev));
    }

}