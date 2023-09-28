"use client";
import { createContext, useContext, useEffect, useState } from "react";
import { get } from "@/api/Usuario.Api";
import { getSP as getPersona } from "@/api/Persona.Api";

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
  const [persona, setPersona] = useState();
  const [rol, setRol] = useState();


  const changePage = (id) => {
    setPaginate((prevPaginate) =>
      prevPaginate.map((page) => ({
        ...page,
        status: page.id === id ? "this" : "other",
      }))
    );
  };

  const Usuario = async (pagina) => {
    const usuario = await get(pagina)
      .then((data) => {
        return data;
      })
      .catch((error) => error);

    return usuario;
  };

  const roles = [
    { id: 1, nombre: "Administracion" },
    { id: 2, nombre: "Digitador" },
    { id: 3, nombre: "Usuario Comun" },
  ];

  useEffect(() => {
    getPersona().then((data) =>
      setPersona(data.map((m) => ({ value: m.id, label: m.nombre })))
    );
    setRol(roles.map((m) => ({ value: m.id, label: m.nombre })))

  }, []);

  return (
    <UsuarioContext.Provider value={{ rol, persona, Usuario, paginate, changePage }}>
      {children}
    </UsuarioContext.Provider>
  );
}

export default UsuarioProvider;
