import LoginProvider from "@/context/Login.Context";
import LoginForm from "@/components/Login/LoginForm";

function page() {
  return (
    <LoginProvider>
      <LoginForm />
    </LoginProvider>
  );
}

export default page;
