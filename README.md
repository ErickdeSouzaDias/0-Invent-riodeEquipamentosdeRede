# 🌐 Inventário de Equipamentos de Rede

Aplicação desenvolvida em **C# / .NET 10** com o objetivo de praticar lógica de programação, orientação a objetos, persistência de dados e operações CRUD através de um cenário relacionado à área de **redes de computadores e infraestrutura**.

O projeto faz parte de uma série de desafios práticos de desenvolvimento, buscando transformar problemas do dia a dia de TI e redes em aplicações de software.

---

## 🚀 Objetivo

Desenvolver um sistema simples para gerenciamento de equipamentos de rede, permitindo cadastrar, consultar, alterar e excluir equipamentos utilizados em uma infraestrutura de rede.

A ideia é aplicar conceitos de programação em um cenário próximo da realidade de um ambiente de **ISP, infraestrutura de redes e suporte técnico**.

---

## 🛠️ Tecnologias utilizadas

* **C#**
* **.NET 10**
* **Entity Framework Core**
* **SQLite**
* **Git / GitHub**
* **Visual Studio Code**

---

## 📋 Funcionalidades

* [x] Cadastro de equipamentos
* [x] Geração automática do código do equipamento
* [x] Persistência dos dados em banco SQLite
* [x] Consulta de equipamentos
* [x] Atualização de equipamentos
* [x] Exclusão de equipamentos
* [x] Registro da data de instalação
* [x] Controle de status do equipamento
* [x] Registro da última manutenção
* [x] Campo para observações

### Informações cadastradas

Cada equipamento pode possuir:

| Campo                | Descrição                               |
| -------------------- | --------------------------------------- |
| `Código`             | Identificador único do equipamento      |
| `Nome/Descrição`     | Nome ou descrição do equipamento        |
| `Tipo`               | Tipo do equipamento                     |
| `Fabricante`         | Fabricante                              |
| `Modelo`             | Modelo do equipamento                   |
| `IP`                 | Endereço IPv4/IPv6                      |
| `Localização`        | Local onde o equipamento está instalado |
| `Data de instalação` | Data em que o equipamento foi instalado |
| `Status`             | Situação atual do equipamento           |
| `Última manutenção`  | Data da última manutenção               |
| `Observação`         | Informações adicionais                  |

---

## 🗄️ Banco de dados

O projeto utiliza **SQLite** para armazenamento dos dados.

O Entity Framework Core é utilizado como ORM para facilitar a comunicação entre a aplicação e o banco de dados.

### Estrutura simplificada

```text
Aplicação C#
      │
      ▼
Entity Framework Core
      │
      ▼
SQLite
      │
      ▼
inventario.db
```

O banco é criado localmente durante a configuração do projeto.

---

## 📂 Estrutura do projeto

```text
InventarioDeEquipamentosDeRede/
│
├── Program.cs
├── Equipamento.cs
├── Status.cs
├── InventarioContext.cs
│
├── Migrations/
│
├── inventario.db
│
└── README.md
```

> A estrutura pode sofrer alterações conforme o projeto evolui durante os desafios.

---

## ⚙️ Como executar

### Pré-requisitos

Tenha instalado:

* [.NET 10 SDK](https://dotnet.microsoft.com/download)
* Git

Verifique a instalação:

```bash
dotnet --version
```

---

### 1. Clone o repositório

```bash
git clone URL_DO_REPOSITORIO
```

Entre no diretório:

```bash
cd InventarioDeEquipamentosDeRede
```

---

### 2. Restaure as dependências

```bash
dotnet restore
```

---

### 3. Crie/atualize o banco de dados

Caso as migrations estejam disponíveis:

```bash
dotnet ef database update
```

---

### 4. Execute a aplicação

```bash
dotnet run
```

---

## 💡 Conceitos praticados

Este projeto tem como foco o desenvolvimento prático de conceitos importantes de C#:

* Variáveis e tipos de dados
* Métodos
* Condicionais
* Estruturas de repetição
* Enumerações (`enum`)
* Classes e objetos
* Encapsulamento
* Listas e coleções
* Manipulação de datas
* Tratamento de exceções
* Serialização e persistência de dados
* Entity Framework Core
* SQLite
* CRUD
* LINQ
* Migrations
* Organização de projetos
* Git e GitHub

---

## 🧠 Evolução do projeto

O projeto começou utilizando **JSON como mecanismo de armazenamento**, permitindo praticar:

```text
C#
   ↓
Objetos
   ↓
JSON
   ↓
Arquivo
```

Posteriormente, o armazenamento foi migrado para SQLite:

```text
C#
   ↓
Entity Framework Core
   ↓
SQLite
   ↓
Banco de dados
```

Essa evolução faz parte da proposta do desafio: começar com uma solução simples e posteriormente aplicar ferramentas e conceitos mais próximos de aplicações reais.

---

## 🔮 Próximos passos

Algumas funcionalidades que podem ser implementadas nas próximas versões:

* [ ] Interface gráfica
* [ ] Pesquisa por IP
* [ ] Pesquisa por fabricante/modelo
* [ ] Filtros por status
* [ ] Histórico de manutenção
* [ ] Cadastro de localidades
* [ ] Cadastro de tipos de equipamentos
* [ ] Relatórios
* [ ] Exportação para CSV/Excel
* [ ] API REST
* [ ] Autenticação de usuários
* [ ] Controle de permissões
* [ ] Dashboard de equipamentos
* [ ] Integração com sistemas de monitoramento

---

## 📚 Sobre o desafio

Este projeto foi desenvolvido como parte de uma sequência de **desafios de programação**, com o objetivo de desenvolver raciocínio lógico e transformar problemas práticos em soluções utilizando diferentes linguagens e tecnologias.

Os desafios podem envolver:

```text
🐍 Python
💻 C#
🐘 PHP
🌐 Web
🗄️ Banco de dados
🐳 Docker
🌐 Redes
⚙️ Automação
```

A proposta é evoluir gradualmente do desenvolvimento de pequenos programas para aplicações mais completas.

---

## 👨‍💻 Autor

**Érick De Souza Dias**

Profissional de TI com atuação em **suporte, infraestrutura e redes de computadores**, utilizando programação e automação para solucionar problemas e melhorar processos.

### Áreas de interesse

* 🌐 Redes de computadores
* 🖥️ Infraestrutura
* 🐧 Linux
* 🐳 Docker
* 💻 C# / .NET
* 🐍 Python
* 🌎 Desenvolvimento Web
* 🗄️ Banco de dados
* ⚙️ Automação

---

## 📄 Licença

Este projeto está disponível para fins de **estudo, aprendizado e demonstração de desenvolvimento**.

Sinta-se à vontade para explorar o código e utilizar o projeto como referência para seus próprios estudos.
