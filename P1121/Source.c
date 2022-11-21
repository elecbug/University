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