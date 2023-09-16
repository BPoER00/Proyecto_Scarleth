"use client";
import { createContext, useContext, useState } from "react";
import { get } from "@/api/Asignacion.Api";

const AsignacionContext = createContext();

export const useAsignacion = () => {
  const context = useContext(AsignacionContext);
  if (!context) throw new Error("useAsignacion must used within a provider");
  return context;
};

function AsignacionProvider({ children }) {
  const defaultPaginate = [
    { id: 1, name: "Lista de Asignacion", status: "this" },
    { id: 2, name: "Nuevas Asignacion", status: "other" },
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

  const Asignacion = async () => {
    const asignacion = await get()
      .then((data) => {
        return data;
      })
      .catch((error) => error);

    return asignacion;
  };

  return (
    <AsignacionContext.Provider value={{ Asignacion, paginate, changePage }}>
      {children}
    </AsignacionContext.Provider>
  );
}

export default AsignacionProvider;
