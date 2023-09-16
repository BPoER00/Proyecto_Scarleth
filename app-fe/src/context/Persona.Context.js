"use client";
import { createContext, useContext, useState } from "react";
import { get } from "@/api/Persona.Api";

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

  const changePage = (id) => {
    setPaginate((prevPaginate) =>
      prevPaginate.map((page) => ({
        ...page,
        status: page.id === id ? "this" : "other",
      }))
    );
  };

  const Persona = async () => {
    const persona = await get()
      .then((data) => {
        return data;
      })
      .catch((error) => error);

    return persona;
  };

  return (
    <PersonaContext.Provider value={{ Persona, paginate, changePage }}>
      {children}
    </PersonaContext.Provider>
  );
}

export default PersonaProvider;
