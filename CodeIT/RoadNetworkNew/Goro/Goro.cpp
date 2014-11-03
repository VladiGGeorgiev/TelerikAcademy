// Goro.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <stdio.h>
#include <tchar.h>
#include <iostream>
#include <set>
#include <vector>
#include <algorithm>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	int numbers[3];
	for (int i = 0; i < 3; i++)
	{
		int num;
		cin >> num;
		numbers[i] = num;
	}

	int count;
	cin >> count;

	int result = 0;
	for (int i = 0; i < count; i++)
	{
		std::vector<int> myvector(numbers, numbers + 3);
		std::sort(myvector.begin(), myvector.begin() + 3);
		result += myvector[2];

		if (myvector[2] >= 0)
		{
			myvector[2]--;
			for (int i = 0; i < 3; i++)
			{
				numbers[i] = myvector[i];
			}
		}
	}
	cout << result;

	return 0;
}

