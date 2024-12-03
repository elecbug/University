#define _CRT_SECURE_NO_WARNINGS
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct Word
{
	char* eng;
	char* kor;
} Word;

typedef struct Hash
{
	Word*** buckets;
	size_t bucket_size;
	size_t slot;
} Hash;

Hash* create_hash(size_t bucket_size, size_t slot)
{
	Hash* result;

	if (result = (Hash*)malloc(sizeof(Hash)))
	{
		result->slot = slot;
		result->bucket_size = bucket_size;

		if (result->buckets = (int***)malloc(sizeof(int**) * bucket_size))
		{
			for (int i = 0; i < bucket_size; i++)
			{
				if (result->buckets[i] = (int**)malloc(sizeof(int*) * slot))
				{
					for (int j = 0; j < slot; j++)
					{
						result->buckets[i][j] = 0;
					}
				}
			}
		}
	}

	return result;
}

void insert_hash(Hash* hash, char* eng, char* kor)
{
	printf("insert %s/%s\n", eng, kor);
	int loc = eng[0] % hash->bucket_size;

	for (int i = 0; i < hash->slot; i++)
	{
		if (!hash->buckets[loc][i])
		{
			if (hash->buckets[loc][i] = (int*)malloc(sizeof(int)))
			{
				Word* word = (Word*)malloc(sizeof(Word));
				word->eng = (char*)malloc(sizeof(20));
				word->kor = (char*)malloc(sizeof(20));
				strcpy(word->eng, eng);
				strcpy(word->kor, kor);
				hash->buckets[loc][i] = word;

				return;
			}
		}
	}

	printf("hash overflow(probing count: %d)\n", hash->slot);
}

int search_hash(Hash* hash, char* eng)
{
	printf("find %s\n", eng);

	int loc = eng[0] % hash->bucket_size;

	for (int i = 0; i < hash->slot; i++)
	{
		if (hash->buckets[loc][i] && strcmp(hash->buckets[loc][i]->eng, eng) == 0)
		{
			printf("%s is %s\n", hash->buckets[loc][i]->eng, hash->buckets[loc][i]->kor);
			return 1;
		}
	}

	printf("not found in hash\n");

	return 0;
}

int delete_hash(Hash* hash, char* eng)
{
	printf("delete %s\n", eng);
	int loc = eng[0] % hash->bucket_size;

	for (int i = 0; i < hash->slot; i++)
	{
		if (hash->buckets[loc][i] && strcmp(hash->buckets[loc][i]->eng, eng) == 0)
		{
			free(hash->buckets[loc][i]);
			hash->buckets[loc][i] = 0;

			return 1;
		}
	}

	printf("do not delete in hash\n");

	return 0;
}

void print_hash(Hash* hash)
{
	for (int i = 0; i < hash->bucket_size; i++)
	{
		printf("%d: ", i);
		for (int j = 0; j < hash->slot; j++)
		{
			if (hash->buckets[i][j])
				printf("%s/%s, ", hash->buckets[i][j]->eng, hash->buckets[i][j]->kor);
			else
				printf("NULL, ");
		}
		printf("\n");
	}
}

int main()
{
	Hash* hash = create_hash(7, 2);
	int arr[20];
	char c = NULL;
	while (c != 'e')
	{
		scanf_s("%c", &c);
		switch (c)
		{
		case 'i':
		{
			char eng[99], kor[99];
			printf("Eng: ");
			scanf("%s", eng);
			printf("Kor: ");
			scanf("%s", kor);
			insert_hash(hash, eng, kor);
		}
		break;
		case 's':
		{
			char eng[99];
			printf("Eng: ");
			scanf("%s", eng);
			search_hash(hash, eng);
		}
		break;
		case 'd':
		{
			char eng[99];
			printf("Eng: ");
			scanf("%s", eng);
			delete_hash(hash, eng);
		}
		break;
		case 'p':
		{
			print_hash(hash);
		}
		break;
		case 'e':
			printf("Exit Hash Program...\n");
			break;
		default:
			break;
		}
	}
}