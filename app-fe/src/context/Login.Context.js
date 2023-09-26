"use client";
import { createContext, useContext, useState } from "react";
import { post } from "@/api/Login.Api";

const LoginContext = createContext();

export const useLogin = () => {
  const context = useContext(LoginContext);
  if (!context) throw new Error("useLogin must used within a provider");
  return context;
};

const Login = async (credentials) => post(credentials);

function LoginProvider({ children }) {
  return (
    <LoginContext.Provider value={{ Login }}>{children}</LoginContext.Provider>
  );
}

export default LoginProvider;
