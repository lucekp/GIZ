Student ma n kursów do zaliczenia. Kursy są poetykietowane od 0 do 
n-1. Niektóre z kursów mają wymagania wstępne, przykładowo aby zaliczyć kurs 0  należy najpierw zaliczyć kurs 1, co jest 
oznaczone jako para (0,1). Mając daną listę wszystkich kursów i ich wymagań, czy jest możliwe ukończenie wszystkich kursów 
przez studenta?

Dane wejściowe:
W pierwszej linii znajduje sie liczba wszystkich kursów n oraz lączna liczba  wymagań m. W każdej z następnych m linii 
znajdują się dwie liczby a, b oddzielone spacją. Oznaczają one, że aby ukończyć kurs a należy wcześniej ukończyć kurs b.
Dane wyjściowe:
Jako wyjście należy podać jedną wartość:
TAK - oznacza, ze możliwe jest zaliczenie listy kursów
NIE - oznacza, ze nie jest możliwe zaliczenie listy kursów
Przykład 1:
Dane wejściowe:
2 1
1 0
Dane wyjściowe:
TAK
Objaśnienie: Są 2 kursy do zaliczenia. Aby podejść do kursu 1 należy najpierw ukończyć kurs 0. Więc jest to możliwe.
Przykład 2:
Dane wejściowe:
2 2
1 0
0 1
Dane wyjściowe:
NIE
Objaśnienie: Są 2 kursy do zaliczenia. Aby wziąć kurs 1 należy najpierw zaliczyć kurs 0, oraz aby zaliczyć kurs 0 należy najpiew zaliczyć kurs 1. A zatem nie jest to możliwe.