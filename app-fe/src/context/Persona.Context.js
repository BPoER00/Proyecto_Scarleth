"use client";
import { createContext, useContext, useState } from "react";

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

  return (
    <PersonaContext.Provider value={{ paginate, changePage }}>
      {children}
    </PersonaContext.Provider>
  );
}

export default PersonaProvider;
