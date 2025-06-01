/************************************************************
 * Autori: Gaina Alexandru, Mazureac Ruben, Petrea Paul-Alberto, Turcu Andrei
 * Data crearii: 2025-05-20
 * Ultima modificare: 2025-05-30
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
    /// <summary>
    /// Testeaza autentificarea reusita a utilizatorului admin cu parola corecta.
    /// </summary>
    [TestMethod]
    public void Test_Login_1()
    {
        Assert.AreEqual(true, proxy.Login("admin", "admin"));
    }

    /// <summary>
    /// Testeaza autentificarea reusita a utilizatorului admin cu parola gresita.
    /// </summary>
    [TestMethod]
    public void Test_Login_2()
    {
        Assert.AreEqual(false, proxy.Login("admin", "1234"));
    }

    /// <summary>
    /// Testeaza autentificarea reusita a utilizatorului alex cu parola corecta.
    /// </summary>
    [TestMethod]
    public void Test_Login_3()
    {
        Assert.AreEqual(true, proxy.Login("alex", "alex"));
    }

    /// <summary>
    /// Testeaza esecul reusita a utilizatorului alex cu parola gresita.
    /// </summary>
    [TestMethod]
    public void Test_Login_4()
    {
        Assert.AreEqual(false, proxy.Login("ana", "Ana"));
    }

    /// <summary>
    /// Testeaza esecul autentificarii utilizatorului ruben cu parola gresita(case sensitive).
    /// </summary>

    [TestMethod]
    public void Test_Login_5()
    {
        Assert.AreEqual(false, proxy.Login("ruben", "Ruben"));
    }

    /// <summary>
    /// Testeaza constructorul User cu username invalid "." si verifica aruncarea exceptiei ArgumentException.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void User_constructor_1()
    {
        User user = new User(".","parola",0);
    }

    /// <summary>
    /// Testeaza constructorul User cu un username valid si nu arunca exceptie.
    /// </summary>
    [TestMethod]
    public void User_constructor_2()
    {
        User user = new User("1234", "parola", 0);
    }

    /// <summary>
    /// Testeaza constructorul User cu username ce contine caracter invalid '.' si verifica aruncarea exceptiei.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void User_constructor_3()
    {
        User user = new User("Gaina.10", "parola", 0);
    }

    /// <summary>
    /// Testeaza constructorul User cu username mai scurt de 3 caractere si verifica aruncarea exceptiei.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void User_constructor_4()
    {
        User user = new User("gx", "parola", 0);
    }

    /// <summary>
    /// Testeaza constructorul User cu username mai lung de 16 caractere si verifica aruncarea exceptiei.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void User_constructor_5()
    {
        User user = new User("qwertyuiopasdfghj", "parola", 0);
    }

    /// <summary>
    /// Testeaza constructorul User cu username ce contine caracter invalid '.' si verifica aruncarea exceptiei.
    /// </summary>
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void User_constructor_6()
    {
        User user = new User("beto.4", "parola", 0);
    }

    /// <summary>
    /// Testeaza ca acelasi input in hasher returneaza acelasi hash.
    /// </summary>
    [TestMethod]
    public void PasswordHasher_HashString_1()
    {
        string input = "parola123";
        string hash1 = PasswordHasher.PasswordHasher.HashString(input);
        string hash2 = PasswordHasher.PasswordHasher.HashString(input);
        Assert.AreEqual(hash1, hash2);
    }

    /// <summary>
    /// Testeaza ca doua inputuri diferite genereaza hashuri diferite.
    /// </summary>
    [TestMethod]
    public void PasswordHasher_HashString_2()
    {
        string hash1 = PasswordHasher.PasswordHasher.HashString("parola123");
        string hash2 = PasswordHasher.PasswordHasher.HashString("Parola123");
        Assert.AreNotEqual(hash1, hash2);
    }

    /// <summary>
    /// Testeaza ca un input gol returneaza un hash valid (nevid).
    /// </summary>
    [TestMethod]
    public void PasswordHasher_HashString_3()
    {
        string hash = PasswordHasher.PasswordHasher.HashString("");
        Assert.IsFalse(string.IsNullOrEmpty(hash));
    }

    /// <summary>
    /// Testeaza hashing-ul unui input ce contine caractere unicode.
    /// </summary>
    [TestMethod]
    public void PasswordHasher_HashString_4()
    {
        string input = "ășțâîă";
        string hash = PasswordHasher.PasswordHasher.HashString(input);
        Assert.IsFalse(string.IsNullOrEmpty(hash));
    }

    /// <summary>
    /// Testeaza ca hashul generat are lungimea de 28 caractere (Base64).
    /// </summary>
    [TestMethod]
    public void PasswordHasher_HashString_5()
    {
        string input = "test";
        string hash = PasswordHasher.PasswordHasher.HashString(input);
        Assert.AreEqual(28, hash.Length);
    }

    /// <summary>
    /// Testeaza ca adaugarea unui meci il include in lista de meciuri.
    /// </summary>
    [TestMethod]
    public void AddMatch()
    {
        var manager = new RealMatchManager();
        var match = new MatchStats.Match("Steaua", "Dinamo", 2, 1);
        manager.AddMatch(match);
        var matches = manager.GetMatches();
        Assert.IsTrue(matches.Contains(match));
    }

    /// <summary>
    /// Testeaza ca stergerea unui meci il elimina din lista de meciuri.
    /// </summary>
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

    /// <summary>
    /// Testeaza ca actualizarea unui meci modifica scorurile acestuia.
    /// </summary>
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

    /// <summary>
    /// Testeaza ca adaugarea unui eveniment il include in lista evenimentelor meciului.
    /// </summary>
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

    /// <summary>
    /// Testeaza ca stergerea unui eveniment il elimina din lista evenimentelor meciului.
    /// </summary>
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