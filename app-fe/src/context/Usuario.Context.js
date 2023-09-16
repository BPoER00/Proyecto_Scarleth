"use client";
import { createContext, useContext, useState } from "react";
import { get } from "@/api/Usuario.Api";

const UsuarioContext = createContext();

export const useUsuario = () => {
  const context = useContext(UsuarioContext);
  if (!context) throw new Error("useUsuario must used within a provider");
  return context;
};

function UsuarioProvider({ children }) {
  const defaultPaginate = [
    { id: 1, name: "Lista de Usuarios", status: "this" },
    { id: 2, name: "Nuevas Usuarios", status: "other" },
  ];

  const [paginate, setPaginate] = useState(defaultPaginate);

  const changePage = (id) => {
    setPaginate((prevPaginate) =>
      prevPaginate.map((page) => ({
        ...page,
        status: page.id === id ? "this" : "other",
      }))
    );
  };

  const Usuario = async () => {
    const usuario = await get()
      .then((data) => {
        return data;
      })
      .catch((error) => error);

    return usuario;
  };


  return (
    <UsuarioContext.Provider value={{ Usuario, paginate, changePage }}>
      {children}
    </UsuarioContext.Provider>
  );
}

export default UsuarioProvider;
