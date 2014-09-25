using System;
using System.Text;

namespace System.Collections.Generic
{
    /// <summary>
    /// Represents a hierarchy of objects or data.  SimpleTree is a root-level alias for SimpleTree and SimpleSubtreeNode.
    /// </summary>
    public class SimpleTree<T> : SimpleTreeNode<T>
    {
        public SimpleTree() { }

        public SimpleTree(T rootNodeValue)
        {
            this.Value = rootNodeValue;
        }

        public SimpleTree(SimpleTreeNode<T> rootNode)
        {
            this.Children = rootNode.Children;
            this.DisposeTraversalDirection = rootNode.DisposeTraversalDirection;
            this.DisposeTraversalType = rootNode.DisposeTraversalType;
            this.Value = rootNode.Value;
            this.Parent = rootNode.Parent;
           
        }
    }
}