using System;
using System.Collections.Generic;
public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Plan:
        // 1. Create a new double array with size 'length'.
        // 2. Iterate from 0 to 'length - 1'.
        //    a. In each iteration, calculate the multiple by multiplying 'number' with (index + 1).
        //    b. Assign the result to the array at the current position.
        // 3. Return the completed array with the calculated multiples.

        double[] multiples = new double[length]; // Step 1: Create the array

        for (int i = 0; i < length; i++) // Step 2: Iterate over the array
        {
            multiples[i] = number * (i + 1); // Step 2a and 2b: Calculate and assign the multiple
            // Additional comment: We multiply 'number' by (i + 1) to get the correct multiple.
        }

        return multiples; // Step 3: Return the array with multiples
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        // Plan:
        // 1. Check that the 'data' list is not empty and that 'amount' is within a valid range.
        // 2. Determine the index from which to rotate:
        //    a. Calculate the starting index of the elements to be moved to the front (data.Count - amount).
        // 3. Get the elements to be moved to the front using GetRange.
        // 4. Get the elements that will stay in the back of the list.
        // 5. Clear the original list.
        // 6. Add the elements obtained in step 3 first, then add those from step 4.
        // 7. The original list will now be rotated to the right by 'amount'.

        if (data == null || data.Count == 0) // Step 1: Check if the list is empty
        {
            // If the list is empty or null, nothing to rotate
            return;
        }

        // Step 2: Calculate the starting index for rotation
        int rotateIndex = data.Count - amount;

        // Step 3: Get the elements to be moved to the front
        List<int> rotatedPart = data.GetRange(rotateIndex, amount);

        // Step 4: Get the elements that remain at the back
        List<int> remainingPart = data.GetRange(0, rotateIndex);

        // Step 5: Clear the original list
        data.Clear();

        // Step 6: Add the rotated elements first, then the remaining ones
        data.AddRange(rotatedPart);
        data.AddRange(remainingPart);

        // Additional comment: The 'data' list is now rotated to the right by 'amount' positions.
    }
}
