namespace Lab2_Tests;

using Lab2;
 
[TestClass]
public class HashTableListTests
{
    [TestMethod]
    public void TestAdd()
    {
        // Arrange
        HashTableList<string, Student> map = new HashTableList<string, Student>();
        Student tim = new Student("Tim", "Stolpe");
        Student simon = new Student("Simon", "Stålnäbb");
        Student markus = new Student("Markus", "Nygren");

        // Assert
        Assert.IsTrue(map.Add(tim.StudentID, tim));
        Assert.IsTrue(map.Add(simon.StudentID, simon));
        Assert.IsTrue(map.Add(markus.StudentID, markus));

        Assert.IsTrue(map.ContainsKey(tim.StudentID));
        Assert.IsTrue(map.ContainsKey(simon.StudentID));
        Assert.IsTrue(map.ContainsKey(markus.StudentID));
    }

    [TestMethod]
    public void TestGet()
    {
        // Arrange
        HashTableList<string, Student> map = new HashTableList<string, Student>();
        Student student = new Student("abc", "def");
        Student got;

        // Alter
        map.Add(student.StudentID, student);
        got = map.Get("v23abcde");

        // Assert
        Assert.IsTrue(got.Equals(student));
    }

    [TestMethod]
    public void TestRemove()
    {
        // Arrange
        HashTableList<string, Student> map = new HashTableList<string, Student>();
        Student student = new Student("abc", "def");

        // Alter
        map.Add(student.StudentID, student);
        map.Remove(student.StudentID);

        // Assert
        Assert.IsFalse(map.ContainsKey("v23abcde"));

    }

    [TestMethod]
    public void TestContainsValue()
    {
        // Arrange
        HashTableList<string, Student> map = new HashTableList<string, Student>();
        Student s1 = new Student("abc", "def");
        Student s2 = new Student("ghi", "jkl");
        Student s3 = new Student("mno", "pqr");


        // Alter
        map.Add(s1.StudentID, s1);

        // Assert
        Assert.IsTrue(map.ContainsValue(s1));
        Assert.IsFalse(map.ContainsValue(s2));
        Assert.IsFalse(map.ContainsValue(s3));
    }

    [TestMethod]
    public void TestContainsKey()
    {
        // Arrange
        HashTableList<string, Student> map = new HashTableList<string, Student>();
        Student s1 = new Student("abc", "def");
        Student s2 = new Student("ghi", "jkl");
        Student s3 = new Student("mno", "pqr");


        // Alter
        map.Add(s1.StudentID, s1);

        // Assert
        Assert.IsTrue(map.ContainsKey("v23abcde"));
        Assert.IsFalse(map.ContainsKey("v23ghijk"));
        Assert.IsFalse(map.ContainsKey("v23mnopq"));

    }

    [TestMethod]
    public void TestClear()
    {
        // Arrange
        HashTableList<string, Student> map = new HashTableList<string, Student>();
        Student s1 = new Student("abc", "def");
        Student s2 = new Student("ghi", "jkl");
        Student s3 = new Student("mno", "pqr");


        // Alter
        map.Add(s1.StudentID, s1);
        map.Add(s2.StudentID, s2);
        map.Add(s3.StudentID, s3);

        // Assert
        Assert.AreEqual(3, map.TotalCount());
        map.Clear();
        Assert.AreEqual(0, map.TotalCount());
    }

    [TestMethod]
    public void TestIsEmpty()
    {
        // Arrange
        HashTableList<string, Student> map = new HashTableList<string, Student>();


        // Assert
        Assert.IsTrue(map.IsEmpty());
        map.Add("h23simst", new Student("simon", "stalnabb"));
        Assert.IsFalse(map.IsEmpty());
    }

    [TestMethod]
    public void TestResizeAuto()
    {
        // Arrange
        HashTableList<string, Student> map = new HashTableList<string, Student>();
        int capacity = map.Capacity();
        int newCapacity;

        // Act
        for (int i = 0; i < 100; i++)
        {
            string fn = "";
            string ln = "";

            for (int j = 0; j < 5; j++)
            {
                fn += Program.GetRandomAlphabet();
            }

            for (int j = 0; j < 5; j++)
            {
                ln += Program.GetRandomAlphabet();
            }

            Student s = new Student(fn, ln);
            map.Add(s.StudentID, s);
        }
        newCapacity = map.Capacity();

        // Assert
        Assert.AreNotEqual(capacity, newCapacity);

    }

    [TestMethod]
    public void TestResizeManual()
    {
        // Arrange
        HashTableList<string, Student> map = new HashTableList<string, Student>();
        int capacity = map.Capacity();
        int newCapacity;

        // Act
        map.Resize(capacity * 2);
        newCapacity = map.Capacity();

        // Assert
        Assert.AreEqual(capacity * 2, newCapacity);
    }
}
