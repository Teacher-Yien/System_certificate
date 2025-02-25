// Bridge pattern
// Step 1: Create the Implementor interface for authentication mechanisms
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System;

public interface IAuthenticationProvider
{
    bool Authenticate(string username, string password);
}

// Step 2: Create concrete implementations of authentication providers
// SQL Database Authentication Provider
public class SqlAuthenticationProvider : IAuthenticationProvider
{
    private readonly string connectionString;

    public SqlAuthenticationProvider(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public bool Authenticate(string username, string password)
    {
        bool isAuthenticated = false;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password); // In production, use proper hashing
                try
                {
                    conn.Open();
                    int userCount = (int)cmd.ExecuteScalar();
                    isAuthenticated = userCount > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        return isAuthenticated;
    }
}

// LDAP Authentication Provider (example of another implementation)
public class LdapAuthenticationProvider : IAuthenticationProvider
{
    private readonly string ldapServer;
    private readonly string domain;

    public LdapAuthenticationProvider(string ldapServer, string domain)
    {
        this.ldapServer = ldapServer;
        this.domain = domain;
    }

    public bool Authenticate(string username, string password)
    {
        // Implement LDAP authentication logic here
        // This is a simplified example
        Console.WriteLine($"Authenticating {username} against LDAP server {ldapServer}");
        return true; // Replace with actual LDAP authentication
    }
}

// OAuth Authentication Provider (another example)
public class OAuthAuthenticationProvider : IAuthenticationProvider
{
    private readonly string clientId;
    private readonly string clientSecret;

    public OAuthAuthenticationProvider(string clientId, string clientSecret)
    {
        this.clientId = clientId;
        this.clientSecret = clientSecret;
    }

    public bool Authenticate(string username, string password)
    {
        // Implement OAuth authentication logic here
        // This is a simplified example
        Console.WriteLine($"Authenticating using OAuth with client ID: {clientId}");
        return true; // Replace with actual OAuth authentication
    }
}

// Step 3: Create the Abstraction
public abstract class LoginSystem
{
    protected IAuthenticationProvider authProvider;

    public LoginSystem(IAuthenticationProvider authProvider)
    {
        this.authProvider = authProvider;
    }

    public abstract bool Login(string username, string password);
}

// Step 4: Create Refined Abstraction
public class StandardLoginSystem : LoginSystem
{
    public StandardLoginSystem(IAuthenticationProvider authProvider) : base(authProvider)
    {
    }

    public override bool Login(string username, string password)
    {
        // Pre-authentication validation
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            MessageBox.Show("Username and password cannot be empty", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        // Use the authentication provider
        bool result = authProvider.Authenticate(username, password);

        // Post-authentication actions
        if (result)
        {
            // Log successful login, update last login time, etc.
            Console.WriteLine($"User {username} logged in successfully");
        }
        else
        {
            // Log failed attempt, implement lockout policy, etc.
            Console.WriteLine($"Failed login attempt for user {username}");
        }

        return result;
    }
}

// Extended login system with additional security features
public class EnhancedLoginSystem : LoginSystem
{
    private readonly int maxAttempts;
    private Dictionary<string, int> failedAttempts = new Dictionary<string, int>();

    public EnhancedLoginSystem(IAuthenticationProvider authProvider, int maxAttempts = 3) : base(authProvider)
    {
        this.maxAttempts = maxAttempts;
    }

    public override bool Login(string username, string password)
    {
        // Check for account lockout
        if (failedAttempts.ContainsKey(username) && failedAttempts[username] >= maxAttempts)
        {
            MessageBox.Show("Account locked due to too many failed attempts", "Security Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        // Validate input
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            MessageBox.Show("Username and password cannot be empty", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        // Use the authentication provider
        bool result = authProvider.Authenticate(username, password);

        // Handle the result
        if (result)
        {
            // Reset failed attempts on successful login
            if (failedAttempts.ContainsKey(username))
            {
                failedAttempts.Remove(username);
            }

            Console.WriteLine($"User {username} logged in successfully with enhanced security");
        }
        else
        {
            // Track failed attempts
            if (!failedAttempts.ContainsKey(username))
            {
                failedAttempts[username] = 1;
            }
            else
            {
                failedAttempts[username]++;
            }

            Console.WriteLine($"Failed login attempt for user {username}. Attempt {failedAttempts[username]} of {maxAttempts}");
        }

        return result;
    }
}

// Step 5: Update the login form to use the Bridge pattern


namespace System_certificate
{
    public partial class login : Form
    {
        private readonly LoginSystem loginSystem;

        public login()
        {
            InitializeComponent();

            // Get connection string
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            // Create authentication provider
            IAuthenticationProvider authProvider = new SqlAuthenticationProvider(connectionString);

            // Create login system
            loginSystem = new StandardLoginSystem(authProvider);

            // Or use enhanced login system if needed:
            // loginSystem = new EnhancedLoginSystem(authProvider, 5);
        }

        private void btnSubmitLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (loginSystem.Login(username, password))
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}