/*
A. Linear Search
1. n개의 랜덤한 정수를 발생시켜 배열에 저장
2. 랜덤한 정수 r개를 발생시키고, 각 각을 1번에서 생성한 배열에서 순차 탐색
3. 순차 탐색에 걸린 시간 측정
4. 위 실험을 n이 500,000부터 500,000씩 증가시키면서 10,000,000개 까지 반복, r은 50개 발생

B. BST
A의 과정을 반복하되, n개의 랜덤한 정수를 발생한 뒤 삽입하는 과정과 시간도 측정
n이 500,000부터 500,000씩 증가시키면서 10,000,000개 까지 반복, r은 100,000개 발생

C. AVL
B의 과정과 동일
*/

#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include <time.h>
#include <string.h>
#include "Structure.h"
#include "TickTime.h"
#include "ArrayFunction.h"
#include "BSTFunction.h"
#include "AVLFunction.h"

element random()
{
	srand(time(0) + rand());

	return rand() * rand();
}

void linear_mode(size_t count, int r, TSaver* saver)
{
	Tick insert;
	Tick find;

	// insert start
	start(&insert);

	Array* arr = create_array(count);
	for (int i = 0; i < count; i++)
	{
		write_array(arr, i, random());
	}

	// insert end
	end(&insert);

	// start timer
	start(&find);

	for (int i = 0; i < r; i++)
	{
		element num = random();

		find_array(arr, num);
	}

	// end timer
	end(&find);

	printf("Array %8d개의 데이터 삽입: %.6llf 초, %2d회 순차 탐색: %.6llf 초, 총 %.6llf 초\n",
		count, get_term(&insert) / (double)1000, r, get_term(&find) / (double)1000,
		(get_term(&find) + get_term(&insert)) / (double)1000);

	saver->insert = get_term(&insert);
	saver->find = get_term(&find);
}

void bst_mode(size_t count, int r, TSaver* saver)
{
	Tick insert;
	Tick search;

	// insert start
	start(&insert);

	BSTN* bst = create_BST();
	for (int i = 0; i < count; i++)
	{
		insert_BST(bst, random());
	}

	// insert end
	end(&insert);

	// start timer
	start(&search);

	for (int i = 0; i < r; i++)
	{
		element num = random();

		search_BST(bst, num);
	}

	// end timer
	end(&search);

	printf("BST %8d개의 데이터 삽입: %.6llf 초, %6d회 순차 탐색: %.6llf 초, 총 %.6llf 초\n",
		count, get_term(&insert) / (double)1000, r, get_term(&search) / (double)1000,
		(get_term(&search) + get_term(&insert)) / (double)1000);

	saver->insert = get_term(&insert);
	saver->find = get_term(&search);
}

void avl_mode(size_t count, int r, TSaver* saver)
{
	Tick insert;
	Tick search;

	// insert start
	start(&insert);

	AVLN* avl = create_AVL();
	for (int i = 0; i < count; i++)
	{
		insert_AVL(avl, random());
	}

	// insert end
	end(&insert);

	// start timer
	start(&search);

	for (int i = 0; i < r; i++)
	{
		element num = random();

		search_AVL(avl, num);
	}

	// end timer
	end(&search);

	printf("AVL %8d개의 데이터 삽입: %.6llf 초, %6d회 순차 탐색: %.6llf 초, 총 %.6llf 초\n",
		count, get_term(&insert) / (double)1000, r, get_term(&search) / (double)1000,
		(get_term(&search) + get_term(&insert)) / (double)1000);

	saver->insert = get_term(&insert);
	saver->find = get_term(&search);
}

void create_file(TSaver* data, size_t count,int mode)
{
	FILE* fp = NULL;
	char str[255] = "";
	char title[255] = "TEST-";
	
	sprintf(str, "%lld", time(0));
	strcat(title, str);
	strcat(title, ".txt");
	
	fp = fopen(title, "w");

	switch (mode)
	{
	case 1: fputs("Linear(array) mode\n", fp); break;
	case 2: fputs("BST mode\n", fp); break;
	case 3: fputs("AVL mode\n", fp); break;
	}

	for (int i = 0; i < count; i++)
	{
		sprintf(str, "%ld : %ld\n", data[i].insert, data[i].find);
		fputs(str, fp);
	}

	fclose(fp);
}

#define COUNT 20

int main()
{
	while (1)
	{
		printf("Select search mode\n 1) Linear(array)\n 2) BST\n 3) AVL\n 4) exit\n>> ");
		switch (getchar())
		{
		case '1': 
		{
			TSaver s[COUNT] = { 0 };
			
			for (int i = 1; i <= COUNT; i++)
			{
				linear_mode(i * 500000, 50, s + i - 1);
			}

			create_file(s, COUNT, 1);
			break;
		}
		case '2':
		{
			TSaver s[COUNT] = { 0 };

			for (int i = 1; i <= COUNT; i++)
			{
				bst_mode(i * 500000, 100000, s + i - 1);
			}

			create_file(s, COUNT, 2);
			break; 
		}
		case '3':
		{
			TSaver s[COUNT] = { 0 };

			for (int i = 1; i <= COUNT; i++)
			{
				avl_mode(i * 500000, 100000, s + i - 1);
			}

			create_file(s, COUNT, 3);
			break; 
		}
		case '4': return;
		}
	}
}