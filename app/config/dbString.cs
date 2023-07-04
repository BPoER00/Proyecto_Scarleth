namespace app.config
{
    public class dbString
    {
        private string host { get; } = Environment.GetEnvironmentVariable("DB_HOST");

        private string db { get; } = Environment.GetEnvironmentVariable("DB_DATABASE");

        private string username { get; } = Environment.GetEnvironmentVariable("DB_USERNAME");

        private string password { get; } = Environment.GetEnvironmentVariable("DB_PASSWORD");

        private string multipleActiveResultSets { get; } = Environment.GetEnvironmentVariable("DB_MULTIPLEACTIVERESULTSETS");

        private string integrated_Security { get; } = Environment.GetEnvironmentVariable("DB_INTEGRATED_SECURITY");

        private string trustServerCertificate { get; } = Environment.GetEnvironmentVariable("DB_TRUSTSERVERCERTIFICATE");

        public String retornar()
        {
            return new String(
                $"Server={this.host};" +
                $"Database={this.db};" +
                $"User={this.username};" +
                $"Password={this.password};" +
                $"MultipleActiveResultSets={this.multipleActiveResultSets};" +
                $"Integrated Security={this.integrated_Security};" +
                $"TrustServerCertificate={this.trustServerCertificate};"
            );
        }
    }
}