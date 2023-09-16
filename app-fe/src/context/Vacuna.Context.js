"use client";
import { createContext, useContext, useState } from "react";
import { get } from "@/api/Vacuna.Api";

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

  const Vacuna = async () => {
    const vacuna = await get()
      .then((data) => {
        return data;
      })
      .catch((error) => error);

    return vacuna;
  };

  return (
    <VacunaContext.Provider value={{ Vacuna, paginate, changePage }}>
      {children}
    </VacunaContext.Provider>
  );
}

export default VacunaProvider;
