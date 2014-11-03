#include <stdio.h>
#include <tchar.h>
#include <iostream>
#include <set>
#include <vector>
#include <algorithm>
#include <iterator>

using namespace std;

struct Edge
{
	int index;
	int from;
	int to;
	int weight;

	Edge(int from, int to, int weight, int index)
	{
		this->from = from;
		this->to = to;
		this->weight = weight;
		this->index = index;
	}
};

struct EdgeComp
{
	bool operator ()(const Edge & a, const Edge & b) const
	{
		if (a.weight == b.weight)
		{
			if (a.from == b.from)
			{
				return a.to < b.to;
			}
			return a.from < b.from;
		}
		return a.weight < b.weight;
	}
};

int GetIndexOfContaining(int vertex, vector< set<int> > trees)
{
	for (int i = 0; i < trees.size(); i++)
	{
		if (trees[i].find(vertex) != trees[i].end())
		{
			return i;
		}
	}

	return -1;
}

int _tmain(int argc, _TCHAR* argv[])
{
	set<Edge, EdgeComp> edges;
	set<int> vertices;

	int numTowns, numAutobans;

	FILE *pFile;
	pFile = fopen("graph.in","r");

	if (pFile != NULL){
		fscanf(pFile,"%d%d",&numTowns,&numAutobans);

        for (int i = 1; i <= numAutobans; i++) {
            int edgeFrom, edgeTo, weight;

            fscanf(pFile, "%d%d%d", &edgeFrom, &edgeTo, &weight);
            edges.insert(Edge(edgeFrom, edgeTo, weight, i));
            vertices.insert(edgeFrom);
            vertices.insert(edgeTo);
        }
	}

	vector< set<int> > trees;

	set<int>::iterator verticesIter;
	for (verticesIter = vertices.begin(); verticesIter != vertices.end(); verticesIter++)
	{
		trees.push_back(set<int>());
		trees[trees.size() - 1].insert(*verticesIter);
	}

	set<Edge, EdgeComp> mstEdges;
	FILE *fout = fopen("graph.out", "w+");

	set<Edge, EdgeComp>::iterator edgeIter;
	for (edgeIter = edges.begin(); edgeIter != edges.end(); edgeIter++)
	{
		Edge current = *edgeIter;
		int fromTreeIndex = GetIndexOfContaining(current.from, trees);
		int toTreeIndex = GetIndexOfContaining(current.to, trees);

		if (fromTreeIndex != toTreeIndex)
		{
		    fprintf(fout, "%d\n", current.index);
			//cout << current.index << endl;
			copy(trees[fromTreeIndex].begin(), trees[fromTreeIndex].end(),
				inserter(trees[toTreeIndex], trees[toTreeIndex].begin()));
			trees.erase(trees.begin() + fromTreeIndex);

			mstEdges.insert(current);
		}

		if (trees.size() == 1)
		{
			break;
		}
	}



	return 0;
}
