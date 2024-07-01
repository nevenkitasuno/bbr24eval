using System;
using System.Collections.Generic;
using Xunit;

namespace AlgorithmsDataStructures2
{
    public class BalancedBSTTests
    {
        // [Fact]
        // public void TestGenerateBBSTArray()
        // {
        //     // Arrange
        //     int[] inputArray = { 1, 2, 3, 4, 5 };
        //     int[] expectedTree = { 3, 1, 4, 2, 5 };

        //     // Act
        //     int[] tree = BalancedBST.GenerateBBSTArray(inputArray);

        //     // Assert
        //     Assert.Equal(expectedTree, tree);
        // }

        [Fact]
        public void TestGenerateBBSTArray_3Elements()
        {
            // Arrange
            int[] inputArray = { 1, 2, 3 };
            int[] expectedTree = { 2, 1, 3 };

            // Act
            int[] tree = BalancedBST.GenerateBBSTArray(inputArray);

            // Assert
            Assert.Equal(expectedTree, tree);
        }

        [Fact]
        public void TestGenerateBBSTArray_3ElementsReverse()
        {
            // Arrange
            int[] inputArray = { 3, 2, 1 };
            int[] expectedTree = { 2, 1, 3 };

            // Act
            int[] tree = BalancedBST.GenerateBBSTArray(inputArray);

            // Assert
            Assert.Equal(expectedTree, tree);
        }

        [Fact]
        public void TestGenerateBBSTArray_General()
        {
            // Arrange
            int[] inputArray = { 3, 21, 0, 8, 10, 6, 4 };
            int[] expectedTree = { 6, 3, 10, 0, 4, 8, 21 };

            // Act
            int[] tree = BalancedBST.GenerateBBSTArray(inputArray);
            
            // Assert
            Assert.Equal(expectedTree, tree);
        }

        [Fact]
        public void TestGenerateBBSTArrayWithEmptyArray()
        {
            // Arrange
            int[] inputArray = new int[0];
            int[] expectedTree = new int[0];

            // Act
            int[] tree = BalancedBST.GenerateBBSTArray(inputArray);

            // Assert
            Assert.Equal(expectedTree, tree);
        }

        [Fact]
        public void TestGenerateBBSTArrayWithSingleValue()
        {
            // Arrange
            int[] inputArray = { 5 };
            int[] expectedTree = { 5 };

            // Act
            int[] tree = BalancedBST.GenerateBBSTArray(inputArray);

            // Assert
            Assert.Equal(expectedTree, tree);
        }
    }
}