# Maze Solver

## Author
- Athif Nirwasito - 13521053 
- Fazel Ginanda - 13521098
- Hanif Muhammad Zhafran - 13521157

## Description

Maze Solver merupakan aplikasi pencarian treasure dalam suatu labirin. Program akan memvisualisasikan hasilnya, dilengkapi dengan rute arah gerak, frekuensi pengecekan node, panjang rute yang terbentuk, dan execution time. 

Prioritas arah traversal adalah Kanan - Bawah - Kiri - Atas

PERHATIAN: Fitur time per step (animasi) belum diimplementasi meskipun sudah ada di UI

## Requirements

- .NET Framework 6.0
- MSBuild 17.4.1 
## Usage

### Build

Dengan Visual Studio, program dapat langsung di build sekaligus dijalankan dengan cara membuka file MazeSolver.sln pada folder src kemudian tekan tombol start pada Visual Studio. Program juga dapat dibuild secara terpisah pada terminal di Visual Studio dengan command msbuild pada folder src. 

Program juga dapat dijalankan secara langsung tanpa dibuild dengan menggunakan build yang sudah ada pada folder bin. Masuk ke dalam folder bin, kemudian jalankan MazeSolver.exe.

### How to Use

1.	Buka aplikasi dengan cara menjalankan executable MazeSolver.exe pada folder bin.
2.	Klik tombol open file untuk memilih file .txt yang akan digunakan sebagai peta.
3.	Pilih algoritma yang akan digunakan untuk proses pencarian. BFS atau DFS harus dipilih salah satu, sedangkan untuk TSP boleh dipilih ataupun tidak.
4.	Lakukan pencarian dengan klik tombol “Visualize”
5.	Rute yang sudah didapat akan ditampilkan pada peta dengan warna hijau, kemudian ditampilkan juga rute arah gerak, frekuensi pemeriksaan node, panjang rute yang didapat, dan juga execution time dari program.
