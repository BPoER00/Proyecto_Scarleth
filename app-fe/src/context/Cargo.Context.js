"use client";
import { createContext, useContext, useEffect, useState } from "react";
import { get, post, getSP } from "@/api/Cargo.Api";

const CargoContext = createContext();

export const useCargo = () => {
  const context = useContext(CargoContext);
  if (!context) throw new Error("useCargo must used within a provider");
  return context;
};

function CargoProvider({ children }) {
  const defaultPaginate = [
    { id: 1, name: "Lista de Cargo", status: "this" },
    { id: 2, name: "Nuevas Cargo", status: "other" },
  ];

  const [paginate, setPaginate] = useState(defaultPaginate);
  const [cargo, setCargo] = useState();

  const changePage = (id) => {
    setPaginate((prevPaginate) =>
      prevPaginate.map((page) => ({
        ...page,
        status: page.id === id ? "this" : "other",
      }))
    );
  };

  const Cargos = async (pagina, filtro) => {
    const cargo = await get(pagina, filtro)
      .then((data) => {
        return data;
      })
      .catch((error) => error);

    return cargo;
  };

  useEffect(() => {
    getSP().then((data) =>
      setCargo(data.map((m) => ({ value: m.id, label: m.nombre })))
    );
  }, []);

  const insert = async (credentials) => post(credentials);

  return (
    <CargoContext.Provider value={{ cargo, insert, Cargos, paginate, changePage }}>
      {children}
    </CargoContext.Provider>
  );
}

export default CargoProvider;
