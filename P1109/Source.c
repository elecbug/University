#include <stdio.h>
#include <stdlib.h>

typedef struct Graph {
	int V;
	int E;
	int** Adj; //이차원 행렬을 위해
} Graph;

Graph* AdjMatrix(int v, int e) {
	Graph* G = (Graph*)malloc(sizeof(Graph));
	if (!G) {
		printf("Memory Error");
		return;
	}
	G->V = v;
	G->E = e;
	G->Adj = (int**)malloc(sizeof(int*) * G->V);
	for (int i = 0; i < G->V; i++)
		G->Adj[i] = malloc(sizeof(int) * G->V);
	for (int i = 0; i < G->V; i++)
		for (int j = 0; j < G->V; j++)
			G->Adj[i][j] = 0;
	return G;
}

Graph* insert_direct(Graph* G)
{
	int u, v;
	for (int i = 0; i < G->E; i++)
	{
		printf("\n Reading Edge %d (u,v) : ", i + 1);
		scanf_s("%d %d", &u, &v);
		if (u >= G->V || v >= G->V) {
			printf(" No such vertex!!");
			exit(0);
		}
		G->Adj[u][v] = 1;
	}
	return G;
}

Graph* insert_undirect_random(Graph* g) {
	int u = rand() % 6 + 5;
	int v;
}

int main()
{
	Graph* g = AdjMatrix(4, 5);
	insert_direct(g);
}