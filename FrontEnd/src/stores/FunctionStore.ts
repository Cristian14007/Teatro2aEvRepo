import { defineStore } from 'pinia';
import { computed, reactive, ref } from 'vue';

interface Obra {
    obraId: number;
    titulo: string;
    imagen: string;
    descripcion: string;
    genero: string;
    valoracion: number;
    precio: number;
  }

export const useFunctionStore = defineStore('FunctionStore', () => {
  // State
  const functions = reactive(new Array<Obra>);
  const selectedFunctionId = ref<number>(-1); // Inicializa con un valor que represente que no hay ninguna obra seleccionada



  // Getter
  // calcula la cantidad de funciones que hay
  const calcularCantidad = computed(() => functions.length);

  // Getter para obtener la obra seleccionada
  const selectedFunction = computed(() => {
    if (selectedFunctionId.value !== null) {
      return functions.find(func => func.obraId === selectedFunctionId.value);
    }
    return null;
  });

  
    const obras = ref<Obra[]>([]);
    const categoriaSeleccionada = ref('');
    const terminoBusqueda = ref('');
    const opcionOrdenacion = ref('');
  
    async function cargarObras() {
      try {
        const response = await fetch('http://dramaskBack.retocsv.es:80/Obra');
        obras.value = await response.json();
      } catch (error) {
        console.error('Error en cargarObras:', error);
      }
    }
  
    function removeFilter() {
      categoriaSeleccionada.value = '';
      terminoBusqueda.value = '';
      opcionOrdenacion.value = '';
    }
  
    return { obras, categoriaSeleccionada, terminoBusqueda, opcionOrdenacion, cargarObras, removeFilter };
  });
