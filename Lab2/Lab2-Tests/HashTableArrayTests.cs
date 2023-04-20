using Lab2;

namespace Lab2_Tests;

[TestClass]
public class HashTableArrayTests
{
    [TestMethod]
    public void TestAdd()
    {
        // Test if program can handle empty strings
        HashTableArray<string, Student> map = new HashTableArray<string, Student>();
        Student emptyLastname = new Student("Markus","");
        Student enmptyFirstname = new Student("", "Stolpe");
        Student emptyName = new Student("", "");


    }

    [TestMethod]
    public void TestGet()
    {

    }

    [TestMethod]
    public void TestRemove()
    {

    }
    [TestMethod]
    public void TestContainsValue()
    {

    }
    [TestMethod]
    public void TestContainsKey()
    {

    }
    [TestMethod]
    public void TestClear()
    {

    }
    [TestMethod]
    public void TestIsEmpty()
    {

    }
    [TestMethod]
    public void TestTotalCount()
    {

    }
    [TestMethod]
    public void TestCount()
    {

    }
    [TestMethod]
    public void TestBucketCount()
    {

    }
    [TestMethod]
    public void TestCapacity()
    {

    }
    [TestMethod]
    public void TestResize()
    {

    }
}