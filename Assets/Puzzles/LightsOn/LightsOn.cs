using UnityEngine;
using System.Collections;

public class LightsOn : MonoBehaviour {

	public MultidimensionalTorch[] torchArray = new MultidimensionalTorch[3];

	public void TorchToggled(int row, int col)
	{
		print ("toggle " + row + ", " + col);
		/*
		if (row > 0)
		{
			torchArray[row-1][col].Toggle();
		}

		if (col > 0)
		{
			torchArray[row][col-1].Toggle();
		}

		if(col < 2)
		{
			torchArray[row][col+1].Toggle();
		}

		if (row < 2)
		{
			torchArray[row+1][col].Toggle();
		}
		*/
		// Check for success

	}
}
