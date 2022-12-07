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
	int** Adj;
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

void DFS(Graph* G, int u)
{
	append(G->list, u);

	for (int v = 0; v < G->V; v++)
	{
		if (!find(G->list, v) && G->Adj[u][v])
		{
			DFS(G, v);
		}
	}
}

Queue* createQueue()
{
	Queue* result = (Queue*)malloc(sizeof(Queue));
	result->head = (Node*)malloc(sizeof(Node));
	result->head->data = 0;
	result->head->link = 0;

	return result;
}

int isEmpty(Queue* q)
{
	return q->head->link == 0;
}

void enQueue(Queue* q, int data)
{
	Node* temp = q->head;

	while (temp->link) temp = temp->link;

	temp->link = (Node*)malloc(sizeof(Node));
	temp->link->data = data;
	temp->link->link = 0;
}

int deQueue(Queue* q)
{
	if (!isEmpty(q))
	{
		Node* temp = q->head->link;
		q->head->link = q->head->link->link;

		int re = temp->data;
		free(temp);

		return re;
	}
}

void BFS(Graph* G, int u, int* Visited) {
	int v;
	Queue* Q = createQueue();
	enQueue(Q, u);
	while (!isEmpty(Q))
	{
		u = deQueue(Q);
		if (!Visited[u])
		{
			append(G->list, u);
		}
		Visited[u] = 1;
		for (v = 0; v < G->V; v++)
		{
			if (!Visited[v] && G->Adj[u][v])
			{
				enQueue(Q, v);
			}
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

	DFS(g1, 0);

	for (Node* temp = g1->list->link; temp != NULL; temp = temp->link)
	{
		printf("%d -> ", temp->data);
	}
	printf("\n");


	Graph* g2 = NULL;

	g2 = AdjMatrix(8, 8);
	g2 = AdjList(g2);

	g2 = insert_direct(g2, 0, 1);
	g2 = insert_direct(g2, 1, 2);
	g2 = insert_direct(g2, 1, 7);
	g2 = insert_direct(g2, 2, 3);
	g2 = insert_direct(g2, 2, 4);
	g2 = insert_direct(g2, 4, 5);
	g2 = insert_direct(g2, 4, 6);
	g2 = insert_direct(g2, 4, 7);


	int* visited = (int*)malloc(sizeof(int) * 8);
	for (int i = 0; i < 8; i++)
	{
		visited[i] = 0;
	}

	BFS(g2, 0, visited);

	for (Node* temp = g2->list->link; temp != NULL; temp = temp->link)
	{
		printf("%d -> ", temp->data);
	}
	printf("\n");
}