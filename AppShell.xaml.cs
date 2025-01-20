using EvaluacionP3DiazDaniel.Data;

namespace EvaluacionP3DiazDaniel
{
    public partial class AppShell : Shell
    {
        private static SQLiteHelper _database;
        public static SQLiteHelper Database => _database ??= new SQLiteHelper(Path.Combine(FileSystem.AppDataDirectory, "DDiaz_countries.db"));
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }

}