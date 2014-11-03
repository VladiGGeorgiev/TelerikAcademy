// Algograms.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <iostream>
#include <stdio.h>
#include <tchar.h>
#include <iostream>
#include <set>
#include <vector>
#include <algorithm>
#include <string>

using namespace std;

int _tmain(int argc, _TCHAR* argv[])
{
	string words[50];

	string word;
	int index = 0;
	while (word != "-1")
	{
		getline(cin, word);
		words[index] = word;
		index++;
	}

	index -= 2;

	for (int i = 0; i < index; i++)
	{
		sort(words[i].begin(), words[i].begin() + index);
	}


	for (int i = 0; i < index - 1; i++)
	{
		for (int j = i + 1; j < index; j++)
		{
		}
	}

	return 0;
}

