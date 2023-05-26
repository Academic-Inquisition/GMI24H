using Lab6;

namespace Lab6_Test
{
    [TestClass]
    public class Lab6_UnitTest
    {
        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        public void AddRoot_ShouldReturnAddedRoot(int value)
        {
            var tree = new Tree<int>();
            var root = new Node<int>(value);

            Assert.AreEqual(root._value, tree.AddRoot(value)._value);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        public void AddRoot_RootExists_ShouldReturnExistingRoot(int value)
        {
            var tree = new Tree<int>();
            var root = tree.AddRoot(value);

            Assert.AreEqual(root, tree.AddRoot(value));
        }



        [TestMethod]
        public void AddChild_NullParent_ShouldThrowException()
        {
            var tree = new Tree<int>();
            Assert.ThrowsException<ArgumentNullException>(() => tree.AddChild(null, 2));
        }

        [TestMethod]
        public void AddChild_ShouldReturnAddedNode()
        {
            var tree = new Tree<int>();
            var root = tree.AddRoot(5);
            var child = new Node<int>(3);

            Assert.AreEqual(child._value, tree.AddChild(root, 3)._value);
        }



        [TestMethod]
        public void FindParent_NullInput_ShouldThrowException()
        {
            var tree = new Tree<int>();
            Assert.ThrowsException<ArgumentNullException>(() => tree.FindParent(null));
        }

        [TestMethod]
        public void FindParent_RootInput_ShouldReturnRoot()
        {
            var tree = new Tree<int>();
            var root = tree.AddRoot(5);

            Assert.AreEqual(root, tree.FindParent(root));
        }

        [TestMethod]
        public void FindParent_NodeInput_ShouldReturnParentNode()
        {
            var tree = new Tree<int>();
            var root = tree.AddRoot(5);
            var child = tree.AddChild(root, 3);

            Assert.AreEqual(root, tree.FindParent(child));
        }


        [TestMethod]
        public void FindNode_ShouldReturnNode()
        {
            var tree = new Tree<int>();
            var root = tree.AddRoot(5);
            var child = tree.AddChild(root, 3);

            Assert.AreEqual(child, tree.FindNode(3));
        }


        [TestMethod]
        public void RemoveNode_NullInput_ShouldThrowException()
        {
            var tree = new Tree<int>();

            Assert.ThrowsException<ArgumentNullException>(() => tree.Remove(null));
        }

        [TestMethod]
        public void RemoveNode_RootInput()
        {
            var tree = new Tree<int>();
            var root = tree.AddRoot(5);
            tree.Remove(root);

            Assert.IsNull(tree.FindNode(5));
        }

        [TestMethod]
        public void RemoveNode_ChildInput()
        {
            var tree = new Tree<int>();
            var root = tree.AddRoot(5);
            var child = tree.AddChild(root, 3);
            tree.Remove(child);

            Assert.IsNull(tree.FindNode(3));
        }

    }
}