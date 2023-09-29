"use client";
import { createContext, useContext, useEffect, useState } from "react";
import { get, post } from "@/api/Asignacion.Api";
import { getSP as getPersona } from "@/api/Persona.Api";
import { getSP as getCargo } from "@/api/Cargo.Api";
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
  const [persona, setPersona] = useState();
  const [cargo, setCargo] = useState();

  const changePage = (id) => {
    setPaginate((prevPaginate) =>
      prevPaginate.map((page) => ({
        ...page,
        status: page.id === id ? "this" : "other",
      }))
    );
  };

  useEffect(() => {
    getPersona().then((data) =>
      setPersona(data.map((m) => ({ value: m.id, label: m.nombre })))
    );
    getCargo().then((data) =>
      setCargo(data.map((m) => ({ value: m.id, label: m.nombre })))
    );
  }, []);

  const Asignacion = async (pagina, filtros) => {
    const asignacion = await get(pagina, filtros)
      .then((data) => {
        return data;
      })
      .catch((error) => error);

    return asignacion;
  };

  const insert = async (credentials) => post(credentials);

  return (
    <AsignacionContext.Provider value={{ insert, persona, cargo, Asignacion, paginate, changePage }}>
      {children}
    </AsignacionContext.Provider>
  );
}

export default AsignacionProvider;
