#Gekozen Datastructure:

datastructuur1 = 'List'
datastructuur2 = 'Dict'
datastructuur3 = 'Tuple'

#Algoritme

algoritme_datastructuur1 = 'Binary search'
algoritme_datastructuur2 = 'Hashing'
algoritme_datastructuur3 = 'Linear search'

#Complexiteit

complexiteit_algoritme1 = 'O (log n)' 
# gaat er van uit dat de lijst al georganiseerd is en zoekt door elke keer het middelste punt te pakken, wordt dus exponentieel verkleind
complexiteit_algoritme2 = 'Gemiddeld O(1), slechtse geval O(n)'
# gebruik gemaakt van een hash tabel, waardoor de tabel een goede index geeft en dus O(1), als meerdere waardes dezelfde index hebben kan het oplopen tot O(n)
complexiteit_algoritme3 = 'O(n)'
# elk element in de tuple wordt een voor een vergeleken tot de gewenste uitkomst, geen hash of index dus is de complexiteit O(n)

#Programmas
namen_dict = {'Alice': 30, 'Bob': 25, 'Charlie': 35, 'David': 40}
namen_list = [1, 2, 3, 4, 5, 6, 7, 8, 9, 33]
namen_tuple = (89, 'Bart', 20.5, [2, 3, 4, 5], 6)

# DATA OPSLAAN
def dict_opslaan(name, age, dict):
    dict[name] = age
    return dict

def list_opslaan(getal, list):
    list.append(getal)
    return list

def tuple_opslaan(item, tuple):
    tuple += (item, )
    return tuple

print(dict_opslaan('Hola', 32, namen_dict))
print(list_opslaan(49494, namen_list))
print(tuple_opslaan('Holle Bolle Gijs', namen_tuple))


# DATA LEZEN
def dict_return(naam, leeftijd_dict):
    return leeftijd_dict.get(naam)

def list_return(aantal, list):
    for i in list:
        if list[i] == aantal:
            return list[i]

def tuple_return(input, tuple):
    lengte = len(tuple)
    for i in range(lengte):
        if tuple[i] == input:
            return tuple[i]

print(f'De leeftijd van Bob is: {dict_return('Bob', namen_dict)}')
print(list_return(33, namen_list))
print(tuple_return(20.5, namen_tuple))