

namespace Lab2_Tests;

using Lab2;

[TestClass]
public class HashTableArrayTests
{
    HashTableArray<string, Student> map = new HashTableArray<string, Student>();
    [TestMethod]

    
    public void TestAdd()
    {
        // Test if program can handle empty strings
        
        Student emptyLastname = new Student("Markus","");
        Student emptyFirstname = new Student("", "Stolpe");
        Student emptyName = new Student("", "");

        map.Add(emptyLastname.StudentID, emptyLastname);
        map.Add(emptyFirstname.StudentID, emptyFirstname);
        map.Add(emptyName.StudentID, emptyName);
        
        Assert.Fail(emptyFirstname.ToString(), emptyLastname.ToString(), emptyName.ToString());

    }

    [TestMethod]
    public void TestGet()
    {
        // test getting a student that doesn´t exist
        Student student = new Student("abc", "def");
        Student studentTest = map.Get("h21blajk");
        Assert.IsTrue(studentTest.Equals(student));
    }

    [TestMethod]
    public void TestRemove()
    {
        // test with student that doesn´t exist
        
        Assert.AreEqual(true, map.Remove("h21blajba"));

    }

    [TestMethod]
    public void TestContainsValue()
    {
        // test with student that doesn´t exist
        Student student = new Student("abc", "def");
        map.ContainsValue(student);

    }

    [TestMethod]
    public void TestContainsKey()
    {
        // test with student that doesn´t exist
        map.ContainsKey("");

    }

    [TestMethod]
    public void TestClear()
    {
        // test clear when the hashtable is already empty?
        map.Clear();
    }

    [TestMethod]
    public void TestIsEmpty()
    {
        // test if empty
        map.IsEmpty();
    }

    [TestMethod]
    public void TestTotalCount()
    {
        // test the size 
        map.TotalCount();
    }

    [TestMethod]
    public void TestCount()
    {
        map.TotalCount();

    }

    [TestMethod]
    public void TestBucketCount()
    {
        // test invalid bucket?
        map.BucketCount(map.Count());
    }

    [TestMethod]
    public void TestCapacity()
    {
        map.Capacity();
    }

    [TestMethod]
    public void TestResize()
    {
        map.Resize(map.Count());
    }
}