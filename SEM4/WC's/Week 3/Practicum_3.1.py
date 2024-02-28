#Maak met python minimaal drie arrays van minimaal 20 willekeurige en niet gesorteerde integers (meer mag ook).

array1 = [18, 89, 90, 95, 62, 34, 65, 54, 68, 90, 42, 77, 61, 71, 48, 83, 20, 67, 17, 56]
array2 = [9, 46, 53, 81, 90, 78, 94, 5, 15, 30, 100, 81, 84, 65, 77, 69, 36, 38, 19, 6]
array3 = [67, 91, 60, 59, 7, 64, 75, 74, 11, 48, 47, 67, 33, 50, 24, 52, 44, 1, 98, 23]

#Zoek op internet naar ten minste drie verschillende sorteeralgoritmes die je wilt gebruiken om de integer arrays mee te sorteren.

" 1. Bubble Sort "
" 2. Insertion Sort "
" 3. Selection Sort "

#Implementer je gekozen sorteeralgoritmes om de integer arrays mee te sorteren. 
#Maak voor elk sorteeralgoritme een nieuwe methode aan die een integer array als parameter heeft en de integer array gesorteerd returnt.

print(f"Niet gesorteerd:\n Array 1: {array1}\n Array 2: {array2}\n Array 3: {array3}\n")

######################################################################

def bubbleSort(arr):
    n = len(arr)

    if n <= 1:
        return #check of er genoeg elementen zijn om te sorteren

    swapped = False

    for i in range(n - 1):
        for j in range(0, n - i - 1):
            if arr[j] > arr[j+1]:
                swapped = True
                arr[j], arr[j+1] = arr[j+1], arr[j]
        if not swapped:
            return

bubbleSort(array1)
print(f"Bubble Sort: \n {array1} \n")

######################################################################

def insertionSort(arr):
    n = len(arr)

    if n <= 1:
        return #check of er genoeg elementen zijn om te sorteren
    
    for i in range(1, n):
        key = arr[i]
        j = i - 1
        
        while j>= 0 and key < arr[j]:
            arr[j+1] = arr[j]
            j -= 1

        arr[j+1] = key

insertionSort(array2)
print(f"Insertion Sort: \n {array2} \n")

#######################################################################

def selectionSort(arr):
    n = len(arr)

    if n <= 1:
        return #check of er genoeg elementen zijn om te sorteren
    
    for i in range (n):
        key = i

        for j in range(i + 1, n):
            if arr[j] < arr[key]:
                key = j
    
        arr[i], arr[key] = arr[key], arr[i]

selectionSort(array3)
print(f"Selection Sort: \n {array3} \n")

######################################################################