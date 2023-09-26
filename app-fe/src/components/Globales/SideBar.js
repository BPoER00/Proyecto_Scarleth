"use client";
import ComponentSidebarTitle from "./SidebarTitle.js";
import ComponentSidebarRedirect from "./SidebarRedirect.js";
import { HomeIcon, PlusIcon } from "@heroicons/react/24/solid";
import Link from "next/link";
import { useRouter } from "next/navigation";
import { useEffect, useState } from "react";
import ProgresBar from "../Inputs/ProgresBar.js";

function SideBar() {
  const router = useRouter();

  const [loading, setLoading] = useState(true);
  const [url, setUrl] = useState("");

  useEffect(() => {
    setLoading(false);

    const currentUrl = window.location.href;

    setUrl(currentUrl);
  }, []);

  const isHome = url.includes("/Dashboard");
  const isPersona = url.includes("/Persona");
  const isAsignacion = url.includes("/Asignacion");
  const isVacunacion = url.endsWith("/Vacunacion");
  const isVacuna = url.endsWith("/Vacuna");
  const isCargo = url.includes("/Cargo");
  const isReportes = url.includes("/Reportes");
  const isUsuario = url.includes("/Usuario");

  return (
    <>
      {loading ? (
        <ProgresBar />
      ) : (
        <div className="fixed flex flex-col top-14 left-0 w-14 hover:w-64 md:w-64 bg-blue-200 dark:bg-gray-700 h-full text-gray-900 dark:text-gray-300 transition-all duration-300 border-none z-10 sidebar">
          <div className="overflow-y-auto overflow-x-hidden flex flex-col justify-between flex-grow">
            <ul className="flex flex-col py-4 space-y-1">
              <ComponentSidebarTitle name={"Opciones"} />

              <Link href={"/Dashboard"}>
                <ComponentSidebarRedirect>
                  <div className="flex items-center justify-between">
                    <span
                      className={`inline-flex justify-center items-center mr-1 ${
                        isHome ? "text-gray-600" : ""
                      } `}
                    >
                      <HomeIcon className="h-7 w-7" />
                    </span>
                    <span
                      className={`ml-2 text-sm font-semibold tracking-wide truncate ${
                        isHome ? "text-gray-600" : ""
                      }`}
                    >
                      Home
                    </span>
                  </div>
                </ComponentSidebarRedirect>
              </Link>

              <button
                type="button"
                onClick={() => {
                  router.push("/Persona");
                  setLoading(true);
                }}
                disabled={isPersona}
              >
                <ComponentSidebarRedirect>
                  <div className="flex items-center justify-between">
                    <p
                      className={`inline-flex justify-center items-center mr-1 ${
                        isPersona ? "text-gray-600" : ""
                      } `}
                    >
                      <PlusIcon className="h-7 w-7" />
                    </p>
                    <span
                      className={`ml-2 text-sm font-semibold tracking-wide truncate ${
                        isPersona ? "text-gray-600" : ""
                      }`}
                    >
                      Persona
                    </span>
                  </div>
                </ComponentSidebarRedirect>
              </button>

              <button
                type="button"
                onClick={() => {
                  router.push("/Asignacion");
                  setLoading(true);
                }}
                disabled={isAsignacion}
              >
                <ComponentSidebarRedirect>
                  <div className="flex items-center justify-between">
                    <p
                      className={`inline-flex justify-center items-center mr-1 ${
                        isAsignacion ? "text-gray-600" : ""
                      } `}
                    >
                      <PlusIcon className="h-7 w-7" />
                    </p>
                    <span
                      className={`ml-2 text-sm font-semibold tracking-wide truncate ${
                        isAsignacion ? "text-gray-600" : ""
                      }`}
                    >
                      Asignacion
                    </span>
                  </div>
                </ComponentSidebarRedirect>
              </button>

              <button
                type="button"
                onClick={() => {
                  router.push("/Vacunacion");
                  setLoading(true);
                }}
                disabled={isVacunacion}
              >
                <ComponentSidebarRedirect>
                  <div className="flex items-center justify-between">
                    <p
                      className={`inline-flex justify-center items-center mr-1 ${
                        isVacunacion ? "text-gray-600" : ""
                      } `}
                    >
                      <PlusIcon className="h-7 w-7" />
                    </p>
                    <span
                      className={`ml-2 text-sm font-semibold tracking-wide truncate ${
                        isVacunacion ? "text-gray-600" : ""
                      }`}
                    >
                      Vacunacion
                    </span>
                  </div>
                </ComponentSidebarRedirect>
              </button>

              <button
                type="button"
                onClick={() => {
                  router.push("/Vacuna");
                  setLoading(true);
                }}
                disabled={isVacuna}
              >
                <ComponentSidebarRedirect>
                  <div className="flex items-center justify-between">
                    <p
                      className={`inline-flex justify-center items-center mr-1 ${
                        isVacuna ? "text-gray-600" : ""
                      } `}
                    >
                      <PlusIcon className="h-7 w-7" />
                    </p>
                    <span
                      className={`ml-2 text-sm font-semibold tracking-wide truncate ${
                        isVacuna ? "text-gray-600" : ""
                      }`}
                    >
                      Vacuna
                    </span>
                  </div>
                </ComponentSidebarRedirect>
              </button>

              <button
                type="button"
                onClick={() => {
                  router.push("/Cargo");
                  setLoading(true);
                }}
                disabled={isCargo}
              >
                <ComponentSidebarRedirect>
                  <div className="flex items-center justify-between">
                    <p
                      className={`inline-flex justify-center items-center mr-1 ${
                        isCargo ? "text-gray-600" : ""
                      } `}
                    >
                      <PlusIcon className="h-7 w-7" />
                    </p>
                    <span
                      className={`ml-2 text-sm font-semibold tracking-wide truncate ${
                        isCargo ? "text-gray-600" : ""
                      }`}
                    >
                      Cargo
                    </span>
                  </div>
                </ComponentSidebarRedirect>
              </button>

              <button
                type="button"
                onClick={() => {
                  router.push("/Reportes");
                  setLoading(true);
                }}
                disabled={isReportes}
              >
                <ComponentSidebarRedirect>
                  <div className="flex items-center justify-between">
                    <p
                      className={`inline-flex justify-center items-center mr-1 ${
                        isReportes ? "text-gray-600" : ""
                      } `}
                    >
                      <PlusIcon className="h-7 w-7" />
                    </p>
                    <span
                      className={`ml-2 text-sm font-semibold tracking-wide truncate ${
                        isReportes ? "text-gray-600" : ""
                      }`}
                    >
                      Reportes
                    </span>
                  </div>
                </ComponentSidebarRedirect>
              </button>

              <button
                type="button"
                onClick={() => {
                  router.push("/Usuario");
                  setLoading(true);
                }}
                disabled={isUsuario}
              >
                <ComponentSidebarRedirect>
                  <div className="flex items-center justify-between">
                    <p
                      className={`inline-flex justify-center items-center mr-1 ${
                        isUsuario ? "text-gray-600" : ""
                      } `}
                    >
                      <PlusIcon className="h-7 w-7" />
                    </p>
                    <span
                      className={`ml-2 text-sm font-semibold tracking-wide truncate ${
                        isUsuario ? "text-gray-600" : ""
                      }`}
                    >
                      Usuarios
                    </span>
                  </div>
                </ComponentSidebarRedirect>
              </button>
            </ul>
            <p className="mb-14 px-5 py-3 hidden md:block text-center text-xs text-gray-600 dark:text-gray-400">
              Copyright @2023 MrKoBP
            </p>
          </div>
        </div>
      )}
    </>
  );
}

export default SideBar;
