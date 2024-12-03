#include <stdio.h>
#include <stdlib.h>
#include <time.h>

typedef struct Node {
	struct Node* link;
	int data;
} Node;

typedef struct Graph {
	int V;
	int E;
	int** Adj; //������ ����� ����
	Node* list;
} Graph;

typedef struct Queue
{
	Node* head;
} Queue;


Graph* AdjList(Graph* g)
{
	g->list = (Node*)malloc(sizeof(Node));
	g->list->link = NULL;
	g->list->data = 0;

	return g;
}

Graph* AdjMatrix(int v, int e)
{
	Graph* G = (Graph*)malloc(sizeof(Graph));
	if (!G) {
		printf("Memory Error");
		return;
	}
	G->V = v;
	G->E = e;
	G->Adj = (int**)malloc(sizeof(int*) * G->V);
	for (int i = 0; i < G->V; i++)
		G->Adj[i] = (int*)malloc(sizeof(int) * G->V);
	for (int i = 0; i < G->V; i++)
		for (int j = 0; j < G->V; j++)
			G->Adj[i][j] = 0;
	return G;
}

Graph* insert_direct(Graph* G, int u, int v)
{
	for (int i = 0; i < G->E; i++)
	{
		if (u >= G->V || v >= G->V) {
			printf(" No such vertex!!");
			exit(0);
		}
		G->Adj[u][v] = 1;
		G->Adj[v][u] = 1;
	}
	return G;
}

int find(Node* list, int u)
{
	while (list != NULL)
	{
		if (list->data == u)
		{
			return 1;
		}

		list = list->link;
	}

	return 0;
}

void append(Node* list, int u)
{
	while (list->link != NULL)
	{
		list = list->link;
	}

	list->link = (Node*)malloc(sizeof(Node));
	list->link->link = NULL;
	list->link->data = u;
}

void DFS(Graph* G, int u, Node* all_edge)
{
	append(G->list, u);
	append(all_edge, u);

	for (int v = 0; v < G->V; v++)
	{
		if (!find(G->list, v) && G->Adj[u][v])
		{
			DFS(G, v, all_edge);
			append(all_edge, u);
		}
	}
}

int main()
{
	Graph* g1 = NULL;

	g1 = AdjMatrix(8, 8);
	g1 = AdjList(g1);

	g1 = insert_direct(g1, 0, 1);
	g1 = insert_direct(g1, 1, 2);
	g1 = insert_direct(g1, 1, 7);
	g1 = insert_direct(g1, 2, 3);
	g1 = insert_direct(g1, 2, 4);
	g1 = insert_direct(g1, 4, 5);
	g1 = insert_direct(g1, 4, 6);
	g1 = insert_direct(g1, 4, 7);
	Node* list = (Node*)malloc(sizeof(Node));
	list->link = 0;

	DFS(g1, 0, list);

	for (Node* temp = list->link; temp != NULL; temp = temp->link)
	{
		printf("%d -> ", temp->data);
	}
	printf("\n");
}