#include <stdio.h>
#include <stdlib.h>

typedef struct Graph {
	int V;
	int E;
	int** Adj; //이차원 행렬을 위해
} Graph;

int Visited[7];

typedef struct Node
{
	int data;
	struct Node* link;
} Node;

typedef struct Queue
{
	Node* head;
} Queue;

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

void BFS(Graph* G, int u) {
	int v;
	Queue* Q = createQueue();
	enQueue(Q, u);
	while (!isEmpty(Q)) {
		u = deQueue(Q);
		printf(" Vertex %d -> ", u);
		Visited[u] = 1;
		for (v = 0; v < G->V; v++) {
			if (!Visited[v] && G->Adj[u][v])
				enQueue(Q, v);
		}
	}
}

int main()
{
	Graph* g = (Graph*)malloc(sizeof(Graph));

	g->V = 7;
	g->E = 6;
	g->Adj = (int**)malloc(sizeof(int*) * 7);

	for (int i = 0; i < 7; i++)
	{
		g->Adj[i] = (int*)malloc(sizeof(int) * 7);

		for (int j = 0; j < 7; j++)
		{
			g->Adj[i][j] = 0;
		}
	}

	g->Adj[1 - 1][2 - 1] = g->Adj[2 - 1][1 - 1] = 1;
	g->Adj[2 - 1][3 - 1] = g->Adj[3 - 1][2 - 1] = 1;
	g->Adj[1 - 1][5 - 1] = g->Adj[5 - 1][1 - 1] = 1;
	g->Adj[2 - 1][5 - 1] = g->Adj[5 - 1][2 - 1] = 1;
	g->Adj[6 - 1][5 - 1] = g->Adj[5 - 1][6 - 1] = 1;
	g->Adj[4 - 1][7 - 1] = g->Adj[7 - 1][4 - 1] = 1;

	BFS(g, 0);

	printf("\n감염된 컴퓨터: ");
	for (int i = 0; i < 7; i++)
	{
		if (Visited[i] == 1)
			printf("%d, ", i + 1);
	}
}
