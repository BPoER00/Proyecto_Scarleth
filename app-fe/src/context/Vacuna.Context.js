"use client";
import { createContext, useContext, useState } from "react";
import { get, post } from "@/api/Vacuna.Api";

const VacunaContext = createContext();

export const useVacuna = () => {
  const context = useContext(VacunaContext);
  if (!context) throw new Error("useVacuna must used within a provider");
  return context;
};

function VacunaProvider({ children }) {
  const defaultPaginate = [
    { id: 1, name: "Lista de Vacuna", status: "this" },
    { id: 2, name: "Nuevas Vacuna", status: "other" },
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

  const Vacuna = async (pagina) => {
    const vacuna = await get(pagina)
      .then((data) => {
        return data;
      })
      .catch((error) => error);

    return vacuna;
  };

  const insert = async (credentials) => post(credentials);

  return (
    <VacunaContext.Provider value={{ insert, Vacuna, paginate, changePage }}>
      {children}
    </VacunaContext.Provider>
  );
}

export default VacunaProvider;
