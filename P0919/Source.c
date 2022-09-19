#include <stdio.h>
#include <stdlib.h>

typedef int element;

typedef struct node
{
	struct node* prev;
	struct node* next;
	element data;
} NODE;

void init(NODE* head)
{
	head->prev = head; // 초기화에서 자기 자신을 가리키는 더블 리스트 노드를 생성
	head->next = head;
}

void insert_front(NODE* head, element data) 
{
	if (head->next == head) // 자기 자신을 가리키는, 즉 원소가 없을 경우 첫 원소 생성
	{
		head->next = (NODE*)malloc(sizeof(NODE));
		head->next->data = data;
		head->next->prev = head;
		head->next->next = NULL;
	}
	else // 그 외의 경우 앞에서 원소 삽입
	{
		NODE* new_node = (NODE*)malloc(sizeof(NODE));
		new_node->prev = head;
		new_node->next = head->next;
		new_node->prev->next = new_node;
		new_node->next->prev = new_node;
		new_node->data = data;
	}
}

void insert_last(NODE* head, element data)
{
	if (head->next == head) // 자기 자신을 가리키는, 즉 원소가 없을 경우 첫 원소 생성
	{
		head->next = (NODE*)malloc(sizeof(NODE));
		head->next->data = data;
		head->next->prev = head;
		head->next->next = NULL;
		head->prev = head->next;
	}
	else // 그 외의 경우 뒤에서 원소 붙임
	{
		NODE* new_node = (NODE*)malloc(sizeof(NODE));
		new_node->next = NULL;
		new_node->prev = head->prev;
		new_node->prev->next = new_node;
		head->prev = new_node;
		new_node->data = data;
	}
}

void show(NODE* head) 
{
	NODE* now = head->next; // 헤드의 다음 즉, 첫 원소부터
	
	while (now != NULL) // null에 도달할 때 까지 전체 순회
	{
		printf("<-|%d|-> ", now->data);
		now = now->next;
	}
}

int main()
{
	NODE* head1 = (NODE*)malloc(sizeof(NODE));
	NODE* head2 = (NODE*)malloc(sizeof(NODE));

	init(head1);
	init(head2);

	for (int i = 0; i < 10; i++)
	{
		insert_front(head1, i);
		show(head1);
		printf("\n");
	}

	for (int i = 0; i < 10; i++)
	{
		insert_last(head2, i);
		show(head2);
		printf("\n");
	}
}