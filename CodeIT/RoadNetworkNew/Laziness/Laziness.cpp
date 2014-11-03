// Laziness.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <stdio.h>
#include <tchar.h>
#include <iostream>
#include <set>
#include <vector>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	int n, a, b;
	cin >> n >> a >> b;
	int numbers[9999];
	for (int i = 0; i < n; i++)
	{
		int number;
		cin >> number;
		numbers[i] = number;
	}


	for (int i = a; i <= b; i++)
	{
		int valueToInsert = numbers[i];
		int position = i;
		while (position > a && valueToInsert < numbers[position - 1])
		{
			numbers[position] = numbers[position - 1];
			position = position - 1;
		}
		numbers[position] = valueToInsert;
	}

	for (int i = 0; i < n; i++)
	{
		cout << numbers[i];
		cout << " ";
	}

	return 0;
}