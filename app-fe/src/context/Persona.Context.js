"use client";
import { createContext, useContext, useEffect, useState } from "react";
import { get } from "@/api/Persona.Api";
import { get as getDireccion } from "@/api/Direccion.Api";
import { get as getGenero } from "@/api/Genero.Api";

const PersonaContext = createContext();

export const usePersona = () => {
  const context = useContext(PersonaContext);
  if (!context) throw new Error("usePersona must used within a provider");
  return context;
};

function PersonaProvider({ children }) {
  const defaultPaginate = [
    { id: 1, name: "Lista de Persona", status: "this" },
    { id: 2, name: "Nuevas Persona", status: "other" },
  ];

  const [paginate, setPaginate] = useState(defaultPaginate);
  const [direccion, setDireccion] = useState();
  const [genero, setGenero] = useState();

  const changePage = (id) => {
    setPaginate((prevPaginate) =>
      prevPaginate.map((page) => ({
        ...page,
        status: page.id === id ? "this" : "other",
      }))
    );
  };

  useEffect(() => {
    getDireccion().then((data) =>
      setDireccion(data.map((m) => ({ value: m.id, label: m.nombre })))
    );
    getGenero().then((data) =>
      setGenero(data.map((m) => ({ value: m.id, label: m.nombre })))
    );
  }, []);

  const Persona = async () => {
    const persona = await get()
      .then((data) => {
        return data;
      })
      .catch((error) => error);

    return persona;
  };

  return (
    <PersonaContext.Provider value={{ direccion, genero, Persona, paginate, changePage }}>
      {children}
    </PersonaContext.Provider>
  );
}

export default PersonaProvider;
