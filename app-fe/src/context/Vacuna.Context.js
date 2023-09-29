"use client";
import { createContext, useContext, useEffect, useState } from "react";
import { get, post, getSP } from "@/api/Vacuna.Api";

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
  const [vacuna, setVacuna] = useState();

  const changePage = (id) => {
    setPaginate((prevPaginate) =>
      prevPaginate.map((page) => ({
        ...page,
        status: page.id === id ? "this" : "other",
      }))
    );
  };

  useEffect(() => {
    getSP().then((data) =>
      setVacuna(data.map((m) => ({ value: m.id, label: m.nombre })))
    );
  }, []);

  const Vacuna = async (pagina, filtro) => {
    const vacuna = await get(pagina, filtro)
      .then((data) => {
        return data;
      })
      .catch((error) => error);

    return vacuna;
  };

  const insert = async (credentials) => post(credentials);

  return (
    <VacunaContext.Provider
      value={{ vacuna, insert, Vacuna, paginate, changePage }}
    >
      {children}
    </VacunaContext.Provider>
  );
}

export default VacunaProvider;
