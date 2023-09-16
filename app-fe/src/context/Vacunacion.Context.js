"use client";
import { createContext, useContext, useState } from "react";
import { get } from "@/api/Vacunacion.Api";

const VacunacionContext = createContext();

export const useVacunacion = () => {
  const context = useContext(VacunacionContext);
  if (!context) throw new Error("useVacunacion must used within a provider");
  return context;
};

function VacunacionProvider({ children }) {
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

  const Vacunacion = async () => {
    const vacunacion = await get()
      .then((data) => {
        return data;
      })
      .catch((error) => error);

    return vacunacion;
  };

  return (
    <VacunacionContext.Provider value={{ Vacunacion, paginate, changePage }}>
      {children}
    </VacunacionContext.Provider>
  );
}

export default VacunacionProvider;
