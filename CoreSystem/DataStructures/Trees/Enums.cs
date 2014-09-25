// This collection of non-binary tree data structures created by Dan Vanderboom.
// Critical Development blog: http://dvanderboom.wordpress.com
// Original Tree<T> blog article: http://dvanderboom.wordpress.com/2008/03/15/treet-implementing-a-non-binary-tree-in-c/

using System;
using System.Text;

namespace System.Collections.Generic
{
    public enum TreeTraversalType
    {
        DepthFirst,
        BreadthFirst
    }

    public enum TreeTraversalDirection
    {
        TopDown,
        BottomUp
    }
}